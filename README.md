# Kitchen Chaos

IMPLEMENTASI SOLID

SRP (Single Responsibility Principle) 
Contoh : PlayerAnimator.cs
![image](https://user-images.githubusercontent.com/101692512/226103392-301b56af-6481-4ffb-924f-42dd130de7ef.png)

Contoh : PlayerControllerCollision.cs
![image](https://user-images.githubusercontent.com/101692512/226104829-4bea0c73-7e17-45b7-a464-f7cd74db7d76.png)

Contoh : PlayerControllerRotation.cs
![image](https://user-images.githubusercontent.com/101692512/226104954-3f9b0fa2-2b3d-4a91-afae-9b5040523e2e.png)

Contoh : PlayerSound.cs
![image](https://user-images.githubusercontent.com/101692512/226104990-0f31027b-c477-4150-8752-cd52c97f4a22.png)

Contoh : PlateComplete.cs
![image](https://user-images.githubusercontent.com/101692512/226105870-3e94738c-884a-47f9-ae26-284065c977cd.png)

SRP List Code : (semua penjelasan kenapa code SRP ada di dalamnya)
PlayerAnimator.cs, PlayerControllerCollision.cs, PlayerControllerInteraction.cs, PlayerControllerMovement.cs, PlayerControllerRotation.cs, KitchenObject.cs, PlateKitchenObj.cs, PlateComplete.cs,  AudioClipScriptableObject.cs, KeyBindingScriptableObject.cs, KitchenScriptableObject.cs, ListPesananScriptableObject.cs, PesananPembeliScriptableObject.cs, resepGosongScriptableObject.cs, resepMasakScriptableObject.cs, resepPotongScriptableObject.cs, ContainerCControllerInteraction.cs, ContainerCounterAnimator.cs, CounterControllerInteraction.cs, CounterSelected.cs, CuttingCControllerInteraction.cs, CuttingCounterAnimator.cs, DeliveryCControllerInteraction, PlateCControllerInteraction.cs, PlateCounterAnimator.cs, StoveCControllerInteraction.cs, StoveCounterAnimator.cs, StoveCounterSoundController.cs, TrashCCountrollerInteraction.cs, DeliveryManagerUI.cs, DeliverManagerSingleUI.cs, GameOverUI.cs, GameStartCountDownAnimator.cs, GameStartCountDownUI.cs, GameTimerUI.cs, DagingMatangKomporUI.cs, DeliveryResultAnimator.cs, DeliveryResultUI.cs, GamePauseUI.cs, MainMenuUI.cs, OptionsUI.cs, PlateVisualIconUI.cs, ProgressBarUI.cs, SinglePlateVisualIconUI.cs, TutorialUI.cs, UILookAtCamera.cs, DeliveryManager.cs, GameInput.cs, KeyGameInputManager.cs, KitchenGameManager.cs, LoaderCallback.cs, LoadingScreenScene.cs, MusicManager.cs, ResetStaticDataManager.cs, SoundManager.cs

LSP (Liskove Substitution Principle)
Contoh : IKitchenObjParent.cs
![image](https://user-images.githubusercontent.com/101692512/226105295-92765a2c-9cfe-4acf-8645-b12a059a7963.png)

LSP List Code : (semua penjelasan kenapa code LSP ada di dalamnya)
IKitchenObjParent.cs, BaseCounter.cs & PlayerControllerInteraction.cs(turunan IKitchenObjParent.cs), IObjectHasProgress.cs, CuttingCControllerInteraction.cs & StoveCControllerInteraction.cs (turunan IObjectHasProgress.cs)


