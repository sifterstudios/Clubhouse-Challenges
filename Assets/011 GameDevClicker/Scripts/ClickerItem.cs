// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SIFTER._011_GameDevClicker.Scripts
{
    public class ClickerItem : MonoBehaviour
    {
        #region Serialized Fields
        [Header("Activation")]
        [SerializeField] Button itemActivationButton;
        [SerializeField] Text itemCountText;

        [Header("Progress")]
        [SerializeField] Image progressForegroundImage;
        [SerializeField] Text progressAwardText;

        [Header("Upgrade")]
        [SerializeField] Button upgradeButton;
        [SerializeField] Text upgradeQuantityText;
        [SerializeField] Text upgradeCostText;

        [Header("Autoplay")]
        [SerializeField] Toggle autoplayToggle;
        [SerializeField] Button unlockAutoplayButton;

        [Header("Lock")]
        [SerializeField] Button unlockItemButton;
        [SerializeField] Text unlockCostText;
        #endregion

        #region Private Variables
        bool isActivated;
        bool canUpgrade;
        bool isAutoplayUnlocked;
        bool isAutoplaying;
        bool isItemUnlocked;

        int index;
        int itemCount;

        float upgradeDuration;
        float upgradeDurationMultiplier;
        float upgradeCostMultiplier;

        double baseUpgradeCost;
        double costOfSingleUpgrade;
        double costOfNextUpgrade;
        double awardValue;
        double initialUnlockCost;
        double autoplayUnlockCost;

        Bank bank;
        #endregion

        #region Challenges
        IEnumerator WorkRoutine()
        {
            float counter = 0;
            isActivated = true;
            itemActivationButton.interactable = false;
            float increment = 1 / (upgradeDuration / upgradeDurationMultiplier);

            //TODO: Display progress made towards the next award.   
            yield return new WaitForEndOfFrame();

            //TODO: Modify players bank balance once progress is complete.

            //TODO: Reset progress once the award value has been credited

            itemActivationButton.interactable = true;
            isActivated = false;
        }

        void InitValues()
        {
            //TODO: Alter these values/formulas to suit your game!
            index = transform.GetSiblingIndex();
            itemCount = 1;

            upgradeDuration = Mathf.Pow(3, index);
            upgradeDurationMultiplier = 1;

            initialUnlockCost = Math.Pow(10, index);

            upgradeCostMultiplier = 1 + (transform.parent.childCount * 2 - index) / 100f;
            baseUpgradeCost = 3 * initialUnlockCost;
            costOfSingleUpgrade = baseUpgradeCost * Math.Pow(upgradeCostMultiplier, itemCount);
            costOfNextUpgrade = costOfSingleUpgrade * bank.CurrentQuantity;

            awardValue = costOfSingleUpgrade / 2;

            autoplayUnlockCost = baseUpgradeCost * (index + 1) * 10;
        }
        #endregion


        #region Unity Methods
        void OnEnable()
        {
            Bank.OnQuantityChanged += UpdateUpgradeQuantity;
        }

        void OnDisable()
        {
            Bank.OnQuantityChanged -= UpdateUpgradeQuantity;
        }

        void Awake()
        {
            bank = FindObjectOfType<Bank>();

            CheckConnections();
        }

        void Start()
        {
            InitValues();
        }

        void Update()
        {
            UpdateDisplay();

            if (!isActivated && isAutoplaying)
            {
                Work();
            }
        }
        #endregion

        #region Public Methods
        public void Work()
        {
            if (!isActivated)
            {
                StartCoroutine(WorkRoutine());
            }
        }

        public void UnlockItem()
        {
            if (!isItemUnlocked && initialUnlockCost <= bank.CurrentBalance)
            {
                bank.ModifyBalance(-initialUnlockCost);
                unlockItemButton.gameObject.SetActive(false);
                isItemUnlocked = true;
            }
        }

        public void UnlockAutoplay()
        {
            if (!isAutoplayUnlocked && autoplayUnlockCost <= bank.CurrentBalance)
            {
                bank.ModifyBalance(-autoplayUnlockCost);
                unlockAutoplayButton.gameObject.SetActive(false);
                isAutoplayUnlocked = true;
            }
        }

        public void ToggleAutoplay()
        {
            isAutoplaying = !isAutoplaying;
            autoplayToggle.isOn = isAutoplaying;
        }

        public void PurchaseUpgrade()
        {
            if (costOfNextUpgrade > bank.CurrentBalance) { return; }

            bank.ModifyBalance(-costOfNextUpgrade);
            itemCount += bank.CurrentQuantity;

            costOfSingleUpgrade = baseUpgradeCost * Math.Pow(upgradeCostMultiplier, itemCount);
            costOfNextUpgrade = costOfSingleUpgrade * bank.CurrentQuantity;

            awardValue = baseUpgradeCost * itemCount;
        }
        #endregion

        #region Private Methods
        void CheckConnections()
        {
            if (itemActivationButton == null)       { Debug.LogWarning(string.Format("[{0}]: itemActivationButton has not been connected.",     GetType().Name)); }
            if (itemCountText == null)              { Debug.LogWarning(string.Format("[{0}]: itemCountText has not been connected.",            GetType().Name)); }
            if (progressForegroundImage == null)    { Debug.LogWarning(string.Format("[{0}]: progressForegroundImage has not been connected.",  GetType().Name)); }
            if (progressAwardText == null)          { Debug.LogWarning(string.Format("[{0}]: progressAwardText has not been connected",         GetType().Name)); }
            if (upgradeButton == null)              { Debug.LogWarning(string.Format("[{0}]: upgradeButton has not been connected.",            GetType().Name)); }
            if (upgradeQuantityText == null)        { Debug.LogWarning(string.Format("[{0}]: upgradeQuantityText has not been connected.",      GetType().Name)); }
            if (upgradeCostText == null)            { Debug.LogWarning(string.Format("[{0}]: upgradeCostText has not been connected.",          GetType().Name)); }
            if (autoplayToggle == null)             { Debug.LogWarning(string.Format("[{0}]: autoplayToggle has not been connected.",           GetType().Name)); }
            if (unlockAutoplayButton == null)       { Debug.LogWarning(string.Format("[{0}]: unlockAutoplayButton has not been connected.",     GetType().Name)); }
            if (unlockItemButton == null)           { Debug.LogWarning(string.Format("[{0}]: unlockItemButton has not been connected.",         GetType().Name)); }
            if (unlockCostText == null)             { Debug.LogWarning(string.Format("[{0}]: unlockCostText has not been connected.",           GetType().Name)); }
        }

        void UpdateDisplay()
        {
            if (!isItemUnlocked)
            {
                unlockCostText.text = string.Format("${0}", initialUnlockCost.ToString("N2"));
                SetItemLockState();
                return;
            }

            itemCountText.text = itemCount.ToString();
            upgradeQuantityText.text = string.Format("{0}x", bank.CurrentQuantity.ToString());

            progressAwardText.text = string.Format("${0}", awardValue.ToString("N2"));
            upgradeCostText.text = string.Format("${0}", costOfNextUpgrade.ToString("N2"));
            progressAwardText.text = string.Format("${0}", awardValue.ToString("N2"));

            SetUpgradeLockState();
            SetAutoplayLockState();
        }

        void UpdateUpgradeQuantity()
        {
            costOfNextUpgrade = costOfSingleUpgrade * bank.CurrentQuantity;
        }

        void SetItemLockState()
        {
            if (initialUnlockCost > bank.CurrentBalance)
            {
                unlockItemButton.interactable = false;
                return;
            }
            unlockItemButton.interactable = true;
        }

        void SetUpgradeLockState()
        {
            if (costOfNextUpgrade > bank.CurrentBalance)
            {
                upgradeButton.interactable = false;
                return;
            }
            upgradeButton.interactable = true;
        }

        void SetAutoplayLockState()
        {
            if (!isAutoplayUnlocked)
            {
                if (autoplayUnlockCost > bank.CurrentBalance)
                {
                    unlockAutoplayButton.interactable = false;
                    return;
                }
                unlockAutoplayButton.interactable = true;
            }
        }
        #endregion
    }
}
