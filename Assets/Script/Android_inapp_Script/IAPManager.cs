using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener
{
    static IAPManager instance;
    public static IAPManager Instance
    {
        get
        {
            return instance;
        }
    }
	static IStoreController storeController = null;
	static string[] sProductIds;

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
        if (storeController == null)
		{
			sProductIds = new string[] { "cash_50", "cash_150","cash_250","cash_550","cash_1800" };
			InitStore();
		}
		
	}

	void InitStore()
	{
		ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
		builder.AddProduct(sProductIds[0], ProductType.Consumable, new IDs { { sProductIds[0], GooglePlay.Name } });
		builder.AddProduct(sProductIds[1], ProductType.Consumable, new IDs { { sProductIds[1], GooglePlay.Name } });
        builder.AddProduct(sProductIds[2], ProductType.Consumable, new IDs { { sProductIds[2], GooglePlay.Name } });
        builder.AddProduct(sProductIds[3], ProductType.Consumable, new IDs { { sProductIds[3], GooglePlay.Name } });
        builder.AddProduct(sProductIds[4], ProductType.Consumable, new IDs { { sProductIds[4], GooglePlay.Name } });

        UnityPurchasing.Initialize(this, builder);
	}

	void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		storeController = controller;
        
        Debug.Log("초기화");

	}

	void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
	{


    }

	public void OnBtnPurchaseClicked(int index)
	{
		if (storeController == null)
		{

        }
		else
			storeController.InitiatePurchase(sProductIds[index]);
	}

	PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs e)
	{
		bool isSuccess = true;
#if UNITY_ANDROID && !UNITY_EDITOR
        Debug.Log(" ");
		CrossPlatformValidator validator = new CrossPlatformValidator(GooglePlayTangle.Data(), AppleTangle.Data(), Application.identifier);
		try
		{
			IPurchaseReceipt[] result = validator.Validate(e.purchasedProduct.receipt);
			for(int i = 0; i < result.Length; i++)
				Analytics.Transaction(result[i].productID, e.purchasedProduct.metadata.localizedPrice, e.purchasedProduct.metadata.isoCurrencyCode, result[i].transactionID, null);
		}
		catch (IAPSecurityException)
		{
			isSuccess = false;
		}
#endif
		if (isSuccess)
		{

			if (e.purchasedProduct.definition.id.Equals(sProductIds[0]))
				AddCoin(50);
			else if (e.purchasedProduct.definition.id.Equals(sProductIds[1]))
				AddCoin(150);
            else if (e.purchasedProduct.definition.id.Equals(sProductIds[2]))
                AddCoin(250);
            else if (e.purchasedProduct.definition.id.Equals(sProductIds[3]))
                AddCoin(550);
            else if (e.purchasedProduct.definition.id.Equals(sProductIds[4]))
                AddCoin(1800);
        }
		else
		{


		}

		return PurchaseProcessingResult.Complete;
	}

	void IStoreListener.OnPurchaseFailed(Product i, PurchaseFailureReason error)
	{
		if (!error.Equals(PurchaseFailureReason.UserCancelled))
		{


		}
	}

	void AddCoin(int value)
	{


        UI_MainManager2.Instatce.UI_Cash  += value;
    }
}

