using Harmony;
using System.Reflection;

// You can use this file almost as-is. Just change the marked lines below. This will be the main file of each mod that tells Harmony to load your changes.
namespace Sprint     // Change this line to match your mod.
{
    public class MainPatcher
    {
        public static void Patch()
        {
            HarmonyInstance harmony = HarmonyInstance.Create("com.glibfire.graveyardkeeper.sprint.mod");   // Change this line to match your mod.
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}