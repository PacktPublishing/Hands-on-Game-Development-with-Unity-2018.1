using UnityEngine;

namespace MyCompany.MyTechnology.Feature 
{
    public class MySampleClass
    {
        private enum Orientations
        {
            PORTRAIT,
            LANDSCAPE,
            SOME_OTHER_VALUE,
        }

        private Orientations orientations = Orientations.PORTRAIT;
        
        /// <summary>
        /// Value indicating this object's height in units
        /// </summary>
        private int height;

        public Texture2D BackgroundTexture { get; set; }
        public int Height
        {
            get { return height; }
        }
    
        public MySampleClass(int height)
        {
            this.height = height;
            if (true)
            {
                //TODO: Do something here
            }
            else
            {
                //TODO: Do something else here
            }
            
            /*
             * Ternary operator usage is great
             * Also notice, we don't use var~!
             */
            int someValue = (height > 0) ? 2 : 1;
        }
    
        /// <summary>
        /// Creates an instance of xyz type.
        /// </summary>
        /// <param name="someDescriptiveName">This name is assigned to
        /// the resulting game object</param>
        private void MakeSomething(string someDescriptiveName)
        {
            /**
             * Though this shouldn't be necessary; when you want to leave
             * long multi-line comments in-code, use the slash-asterisk
             * style comments.
             */
            Debug.Log(string.Format("Some descriptive name: {0}", someDescriptiveName));
        }
    }
}
