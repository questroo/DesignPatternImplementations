using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator
{
    public class Locator
    {
        private static NullAudio nullService;

        private static Audio service;

        static Locator()
        {
            nullService = new NullAudio();
            service = nullService;
        }

        public static Audio GetAudio()
        {
            return service;
        }

        // Use dependency injection to get a reference to the audio service we need
        // Call this method before you do anything else with the audio
        public static void Provide(Audio _service)
        {
            // Sometimes we set to null to disable audio
            if(_service == null)
            {
                service = nullService;
            }
            else
            {
                service = _service;
            }
        }
    }
}