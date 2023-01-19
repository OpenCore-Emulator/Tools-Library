namespace WowHeadItem.Helpers;

public static class LevenshteinDistance
{
    public static int Calculate(string s1, string s2)
    {

        // On définit la longueur des deux chaines de caractères
        int n = s1.Length;
        int m = s2.Length;

        if (n > m)
        {
            (n, m) = (m, n);
            (s1, s2) = (s2, s1);
        }
        
        string s3 = s2.Remove(n, m - n);
        if(s3 == s1)
            return Int32.MinValue;
        
        // Si l'une d'elles est vide, on retourne la longueur de l'autre
        if (n == 0)
            return m;
        
        if (m == 0)
            return n;
        
        // On crée deux tableaux qui vont nous permettre de stocker les distances entre les deux chaines
        int[] v0 = new int[m + 1];
        int[] v1 = new int[m + 1];

        // On crée deux tableaux qui vont nous permettre de stocker les distances entre les deux chaines
        for (int i = 0; i <= m; i++)
        {
            v0[i] = i;
        }
        
        // On remplit le premier tableau avec des valeurs qui correspondent à la distance entre la chaine vide et la chaine 2
        for (int i = 0; i < n; i++)
        {
            v1[0] = i + 1;
            
            // On remplit le second tableau avec des valeurs qui correspondent à la distance entre la chaine 1 et la chaine vide
            for (int j = 0; j < m; j++)
            {
                // On définit un coût qui est 0 si les caractères à la même position dans les deux chaines sont identiques, sinon il vaut 1
                int cost = (s1[i] == s2[j]) ? 0 : 1;
                // On utilise le coût pour mettre à jour la distance entre les deux chaines en prenant la distance minimale entre les différentes possibilités
                v1[j + 1] = Math.Min(Math.Min(v1[j] + 1, v0[j + 1] + 1), v0[j] + cost);
            }
            
            // On fait une copie des valeurs de v1 dans v0 pour pouvoir les utiliser lors de l'itération suivante
            for (int j = 0; j <= m; j++)
            {
                v0[j] = v1[j];
            }
        }
        
        // On retourne la distance entre les deux chaines qui se trouve dans la dernière case de notre tableau v1
        return v1[m];
    }
}