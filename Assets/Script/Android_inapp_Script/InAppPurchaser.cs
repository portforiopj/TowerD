using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;
using UnityEngine.Analytics;
using UnityEngine.UI;
using System;
public class InAppPurchaser : MonoBehaviour, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;

    static InAppPurchaser instance;
    public static InAppPurchaser Instatce
    {
        get
        {
            return instance;
        }
    }
    #region 상품ID
    // 상품ID는 구글 개발자 콘솔에 등록한 상품ID와 동일하게 해주세요.
    public const string productId1 = "cash_50";
    public const string productId2 = "cash_150";
    public const string productId3 = "cash_250";
    public const string productId4 = "cash_550";
    public const string productId5 = "cash_1800";
    #endregion
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {

            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }

    void Start()
    {
        InitializePurchasing();
    }

    private bool IsInitialized()
    {
        return (storeController != null && extensionProvider != null);
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
            return;

        var module = StandardPurchasingModule.Instance();

        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        builder.AddProduct(productId1, ProductType.Consumable, new IDs
        {
            { productId1, AppleAppStore.Name },
            { productId1, GooglePlay.Name },
        });

        builder.AddProduct(productId2, ProductType.Consumable, new IDs
        {
            { productId2, AppleAppStore.Name },
            { productId2, GooglePlay.Name }, }
        );

        builder.AddProduct(productId3, ProductType.Consumable, new IDs
        {
            { productId3, AppleAppStore.Name },
            { productId3, GooglePlay.Name },
        });

        builder.AddProduct(productId4, ProductType.Consumable, new IDs
        {
            { productId4, AppleAppStore.Name },
            { productId4, GooglePlay.Name },
        });

        builder.AddProduct(productId5, ProductType.Consumable, new IDs
        {
            { productId5, AppleAppStore.Name },
            { productId5, GooglePlay.Name },
        });

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyProductID(string productId)
    {
        try
        {
            if (IsInitialized())
            {
                Product p = storeController.products.WithID(productId);

                if (p != null && p.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", p.definition.id));
                    storeController.InitiatePurchase(p);
                }
                else
                {
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            else
            {
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }
        catch (Exception e)
        {
            Debug.Log("BuyProductID: FAIL. Exception during purchase. " + e);
        }
    }

    public void RestorePurchase()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = extensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions
                (
                    (result) => { Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore."); }
                );
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController sc, IExtensionProvider ep)
    {
        Debug.Log("OnInitialized : PASS");

        storeController = sc;
        extensionProvider = ep;
    }

    public void OnInitializeFailed(InitializationFailureReason reason)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + reason);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

        switch (args.purchasedProduct.definition.id)
        {
            case productId1:

                AddCoin(50);

                break;

            case productId2:

                AddCoin(150);

                break;

            case productId3:

                AddCoin(250);

                break;

            case productId4:

                AddCoin(550);

                break;

            case productId5:

                AddCoin(1800);

                break;
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
    void AddCoin(int value)
    {


        UI_MainManager2.Instatce.UI_Cash += value;
    }
}
