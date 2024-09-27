﻿namespace TangoAttack
{
    public static class Program
    {
        public static int XOR(int a, int b) => a ^ b;
        public static int AND(int a, int b) => a & b;

        public static void Main(string[] args)
        {
            int bitLength = 4;
            Random random = new Random();

            // Inicialización de la etiqueta (Tag) con valores aleatorios
            int PID2 = random.Next(0, (1 << bitLength));
            int ID = random.Next(0, (1 << bitLength));
            //ID = 0x52;
            var server = new Server();
            var (K1, K2) = server.ProvideKeys(PID2);
            var tag = new Tag(PID2, PID2, ID, K1, K2);

            // Inicialización del lector
            var reader = new Reader();
            reader.RequestCertificate(server); // Paso 1

            // El lector solicita las claves del servidor usando PID2 (Paso 3)
            int n1 = random.Next(0, (1 << bitLength)); // Nonce n1
            int n2 = random.Next(0, (1 << bitLength)); // Nonce n2
            var (A, B, D) = reader.GenerateMessages(PID2, K1, K2, n1, n2); // Paso 4

            // La etiqueta genera respuesta E y F (Paso 5)
            var (E, F) = tag.GenerateResponse(A, B, D, n1, n2);

            // El lector verifica F y recupera ID (Paso 6)
            int recoveredID = reader.VerifyTagResponse(E, F, K1, K2, n1, n2);

            PassiveTangoCryptanalysis.Session(PID2, A, B, D, E, F);

            // Actualización de pseudónimos en la etiqueta
            tag.UpdatePseudonyms(n1, n2);
        }
    }
}