using UnityEngine;

namespace Assets.Scripts.DI_Framework
{
    public class InjectorHelper
    {
        private readonly Zenject.DiContainer diContainer;

        public InjectorHelper(Zenject.DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        /// <summary>
        /// Add a component to a GameObject and inject all needed DI properties on the added component.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// You only have to use this if you add components to GameObjects on-the-fly / programatically.
        /// Normally on scene load all components on all GameObjects are automatically decorated
        /// with the needed DI.
        public void AddComponentToGameObject<T>(GameObject gameObject) where T : UnityEngine.Component
        {
            diContainer.Inject(gameObject.AddComponent<T>());
        }
    }
}
