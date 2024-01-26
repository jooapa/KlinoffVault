
namespace TakedownOS
{
    // TakedownOS Path system. 
    // Always starts at TakeDownOS/ and can be changed with cd
    public class Utils {
        public static string isolatedRoot = "TakedownOS"; // this is the isolated root directory
        public static string[] isolatedCurrentPath = new string[] { isolatedRoot }; // this is the current relative path in isolated root directory
        public static string absolutePathToRoot = ""; // this is set at the start of the program // this is the current absolute path
        public static string klinoffInterpiterPath = "";
    }
}
