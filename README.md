Modular Shop System

A Unity shop implementation demonstrating domain-driven architecture with strict isolation between modules. Each resource type (health, gold, VIP, location) lives in its own domain knowing nothing about others - the shop works with abstract requirements and rewards, making it trivial to add new resource types without touching existing code. Features manual DI, reactive data binding, ScriptableObject configs for designers, async purchase flow with UniTask, and unit tests. Built in Unity 2022.3.
