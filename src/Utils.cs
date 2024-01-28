
namespace KlinoffVault
{
    // KlinoffVault Path system. 
    // Always starts at KlinoffVault/ and can be changed with cd
    public class Utils {
        public static string isolatedRoot = "KlinoffVault"; // this is the isolated root directory
        public static string[] isolatedCurrentPath = new string[] { isolatedRoot }; // this is the current relative path in isolated root directory
        public static string absolutePathToRoot = ""; // this is set at the start of the program // this is the current absolute path
        public static string klinoffInterpiterPath = "";
    }
}
