using UnityEngine;
namespace ServiceLocator
{
    //Implementation of the Service Locator example from the book Game Programming Patters
    //This class used to test that the implementation is working
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            ConsoleAudio audio = new ConsoleAudio();

            Locator.Provide(audio);
        }

        private void Update()
        {
            Audio audio = Locator.GetAudio();

            if (Input.GetKeyDown(KeyCode.P))
            {
                audio.PlaySound(23);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                audio.StopSound(23);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                audio.StopAllSounds();
            }
        }
    }
}
