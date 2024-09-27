namespace TangoAttack
{
    public class PassiveTangoCryptanalysis
    {
        public static void Session(int PID2, int A, int B, int D, int E, int F)
        {
            /*
            (E⊕F)
            (A⊕B⊕E)
            (A⊕D⊕E)
            (A⊕E⊕F)
            (B⊕D⊕E)
            (D⊕E⊕F)
            (A⊕B⊕D⊕E)
            (A⊕D⊕E⊕F)
            (B⊕D⊕E⊕F)
            */

            Console.WriteLine($"E ^ F  = {E ^ F}");
            Console.WriteLine($"A ^ B ^ E  = {A ^ B ^ E}");
            Console.WriteLine($"A ^ D ^ E  = {A ^ D ^ E}");
            Console.WriteLine($"A ^ E ^ F  = {A ^ E ^ F}");
            Console.WriteLine($"B ^ D ^ E  = {B ^ D ^ E}");
            Console.WriteLine($"D ^ E ^ F  = {D ^ E ^ F}");
            Console.WriteLine($"A ^ B ^ D ^ E  = {A ^ B ^ D ^ E}");
            Console.WriteLine($"A ^ D ^ E ^ F  = {A ^ D ^ E ^ F}");
            Console.WriteLine($"B ^ D ^ E ^ F  = {B ^ D ^ E ^ F}");

        }
    }
}