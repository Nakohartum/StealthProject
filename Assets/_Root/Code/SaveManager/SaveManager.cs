namespace _Root.Code.SaveManager
{
    public class SaveManager
    {
        private static SaveManager _instance;

        public static SaveManager Instance
        {
            get
            {
                return _instance ??= new SaveManager();
            }
        }

        public float LoadHealth()
        {
            //TODO Create a healthAmountLoadingSystem
            return 100f;
        }
    }
}