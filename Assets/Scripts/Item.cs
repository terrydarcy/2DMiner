using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public enum ItemType {
        woodPickaxe,
        woodShovel,
        woodSword,
    }

    public ItemType itemType;
    public int amount;

    public Sprite getSprite () {
        switch (itemType) {
            default:
                case ItemType.woodPickaxe:
                return ItemAssets.Instance.woodPickaxe;
            case ItemType.woodShovel:
                    return ItemAssets.Instance.woodShovel;
            case ItemType.woodSword:
                    return ItemAssets.Instance.woodSword;
        }
    }

    public float getPrice () {
        switch (itemType) {
            default:
                case ItemType.woodPickaxe:
                return 100f;
            case ItemType.woodShovel:
                    return 0f;
            case ItemType.woodSword:
                    return 1000f;
        }
    }

    public string getName () {
        switch (itemType) {
            default:
                case ItemType.woodPickaxe:
                return "wood pickaxe";
            case ItemType.woodShovel:
                    return "wood shovel";
            case ItemType.woodSword:
                    return "wood sword";
        }
    }

    public string getMineSpeed () {
        switch (itemType) {
            default:
                case ItemType.woodPickaxe:
                return "slow";
            case ItemType.woodShovel:
                    return "slow";
            case ItemType.woodSword:
                    return "slow";
        }
    }

    public string getToolTip () {
        switch (itemType) {
            default:
                case ItemType.woodPickaxe:
                return "can mine hard blocks!";
            case ItemType.woodShovel:
                    return "can mine soft blocks!";
            case ItemType.woodSword:
                    return "can defend yourself!";
        }
    }

    public bool isEquipable () {
        switch (itemType) {
            default:
                case ItemType.woodPickaxe:
                return true;
            case ItemType.woodShovel:
                    return true;
            case ItemType.woodSword:
                    return true;
        }
    }

    public bool canBreak (string block) {
        if (itemType == ItemType.woodPickaxe) {
            if (block == "grass") return false;
            if (block == "dirt") return false;
            if (block == "stone") return true;
            if (block == "coal") return true;
        }
        if (itemType == ItemType.woodShovel) {
            if (block == "grass") return true;
            if (block == "dirt") return true;
            if (block == "stone") return false;
            if (block == "coal") return false;
        }
        if (itemType == ItemType.woodShovel) {
            return false;
        }
        return false;
    }
}