using DIKUArcade.Events;

// A Singleton Eventbus (observerpattern?).
namespace SuperMarioBroski {
    public static class SuperBus {
        private static GameEventBus eventBus;
        public static GameEventBus GetBus() {
            return SuperBus.eventBus ?? (SuperBus.eventBus = new GameEventBus());
        }
    }
}