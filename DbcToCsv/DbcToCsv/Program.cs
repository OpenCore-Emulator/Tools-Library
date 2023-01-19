using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;

namespace DbcToCsv;

public class Program
{
    static void Main(string[] args)
    {
        var fieldsInfo = DbcStructDeducer.DeduceStruct("C:\\Users\\BugsBunny\\Downloads\\ItemDisplayInfo.dbc");
        var spellIconStructType = TypeGenerator.GenerateType("SpellIconStruct", fieldsInfo);
        
        var dbcFileType = typeof(DbcFile<>).MakeGenericType(spellIconStructType);
        object dbcFile = Activator.CreateInstance(dbcFileType, "C:\\Users\\BugsBunny\\Downloads\\ItemDisplayInfo.dbc");
        var stringBlockProperty = dbcFileType.GetProperty("string_block");
        // var stringBlock = stringBlockProperty.GetValue(dbcFile);
    }
}

/// <summary>
/// DEBUT !
/// </summary>

public class DbcStructDeducer
{
    public static Dictionary<string, (Type type, int offset)> DeduceStruct(string dbcFilePath)
    {
        var fields = new List<(string name, Type type, int offset)>();

        using (var reader = new BinaryReader(File.OpenRead(dbcFilePath)))
        {
            var header = new DbcHeader();
            header.magic = reader.ReadUInt32();
            header.recordCount = reader.ReadUInt32();
            header.fieldCount = reader.ReadUInt32();
            header.recordSize = reader.ReadUInt32();
            header.stringBlockSize = reader.ReadUInt32();

            var offset = Marshal.SizeOf(header);
            for (int i = 0; i < header.fieldCount; i++)
            {
                var name = $"field{i}";
                var type = typeof(int);
                fields.Add((name, type, offset));
                offset += Marshal.SizeOf(type);
            }
        }
        var fieldsInfo = new Dictionary<string, (Type type, int offset)>();
        foreach (var field in fields)
        {
            fieldsInfo.Add(field.name, (field.type, field.offset));
        }
        return fieldsInfo;
    }
}
class DbcFile<T>
{
    public DbcHeader header;
    public T[] records;
    public string stringBlock;

    public DbcFile(string dbcFilePath)
    {
        using (var reader = new BinaryReader(File.OpenRead(dbcFilePath)))
        {
            header = new DbcHeader();
            header.magic = reader.ReadUInt32();
            header.recordCount = reader.ReadUInt32();
            header.fieldCount = reader.ReadUInt32();
            header.recordSize = reader.ReadUInt32();
            header.stringBlockSize = reader.ReadUInt32();
            
            
            /* Ne pas utiliser Marshal */
            /* Ne fonctionne pas encore
            List<byte[]> records = new();
            for (int i = 0; i < header.recordCount; i++)
            {
                byte[] recordBytes;
                reader.Read(recordBytes, 0, recordBytes.Length);
                
                records[i] = recordBytes;
            }
            */

            var stringBlockBytes = reader.ReadBytes((int)header.stringBlockSize);
            stringBlock = Encoding.UTF8.GetString(stringBlockBytes);
        }
    }
}

public class TypeGenerator
{
    public static Type GenerateType(string typeName, Dictionary<string, (Type type, int offset)> fieldsInfo)
    {
        var typeBuilder = AssemblyBuilder
            .DefineDynamicAssembly(new AssemblyName(typeName), AssemblyBuilderAccess.Run)
            .DefineDynamicModule(typeName)
            .DefineType(typeName, TypeAttributes.Public);

        foreach (var field in fieldsInfo)
        {
            typeBuilder.DefineField(field.Key, field.Value.type, FieldAttributes.Public);
        }

        return typeBuilder.CreateType();
    }
}

struct DbcHeader
{
    public uint magic; // always 'WDBC'
    public uint recordCount; // records per file
    public uint fieldCount; // fields per record
    public uint recordSize; // sum (sizeof (field_type_i)) | 0 <= i < field_count. field_type_i is NOT defined in the files.
    public uint stringBlockSize;
}

enum FieldType
{
    Int32 = 0,
    Float = 1,
    String = 2
}