using System;

namespace Laba9
{
    class Program
    {
        delegate void UserHandler(int param);
        delegate void StringHandler(string str);
        
        static void Main(string[] args)
        {
            User user = new User(0, 500);
            user.Notifier += Message;
            UserHandler uh = user.Move;
            var PrintStr = new StringHandler(StringOps.PrintStr);
            uh += user.Shrink;
            uh(2);
            string str =
                "\nStan,   Stan,   son\nListen,   man,   Dad   isn't   mad\nBut how you gonna name yourself after a damn gun\nAnd have a man-bun?";
            foreach (var word in StringOps.LicketySplit(StringOps.RemoveDoubleSpaces(StringOps.RemoveCommas(str))))
            {
                PrintStr(StringOps.Caps(word));
            }
        }
        private static void Message(string msg)
        {
            StringOps.PrintStr(msg);
        }
    }
}