using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats stats;
    private int _sta = 0;
    private int _str = 0;
    private int _int = 0;
    private int _dex = 0;

    private int _availableStats = 0;
    private int _addSta = 0;
    private int _addStr = 0;
    private int _addInt = 0;
    private int _addDex = 0;

    private int _level = 1;
    private int _exp = 0;
    private int _maxExp = 100;
    public int _hp = 100;
    private int _maxHp = 100;

    public TextMeshProUGUI levelGUI;
    public TextMeshProUGUI hpGUI;
    public TextMeshProUGUI expGUI;
    public TextMeshProUGUI staGUI;
    public TextMeshProUGUI strGUI;
    public TextMeshProUGUI intGUI;
    public TextMeshProUGUI dexGUI;
    public TextMeshProUGUI addStaGUI;
    public TextMeshProUGUI addStrGUI;
    public TextMeshProUGUI addIntGUI;
    public TextMeshProUGUI addDexGUI;
    public TextMeshProUGUI statPointsGUI;

    public int getStr () {
        return _str;
    }

    public bool IsDead()
    {
        return _hp <= 0;
    }

    public void Reset()
    {
        _hp = (int)getMaxHp();
        _maxHp = (int)getMaxHp();
        _maxExp = (int)getMaxExp();
    }

    private void Awake()
    {
        stats = this;

        // _animator = GetComponent<Animator>();
        _hp = (int)getMaxHp();
        _maxHp = (int)getMaxHp();
        _exp = 0;
        _maxExp = (int)getMaxExp();
    }

    void Start()
    {
        //StartCoroutine(ExpTest());
    }

    // Check what keys are being pressed to move the player.
    void Update()
    {
        if (_hp == 0) DamagePlayer(0);

        levelGUI.text = "Level " + _level;
        hpGUI.text = "HP: " + _hp + " / " + _maxHp;
        expGUI.text = "EXP: " + _exp + " / " + _maxExp;

        staGUI.text = "STA: " + _sta;
        strGUI.text = "STR: " + _str;
        intGUI.text = "INT: " + _int;
        dexGUI.text = "DEX: " + _dex;

        addStaGUI.text = "STA: " + _addSta;
        addStrGUI.text = "STR: " + _addStr;
        addIntGUI.text = "INT: " + _addInt;
        addDexGUI.text = "DEX: " + _addDex;

        statPointsGUI.text = "Stat Points: " + _availableStats;
    }

    private float getMaxExp()
    {
        return 100 * Mathf.Pow((1.2f), _level - 1);
    }

    private float getMaxHp()
    {
        return 25 * Mathf.Pow((1.05f), _sta) + _level * 3 + _sta * 3;
    }

    public void GiveHealth(int health) {
        _hp += health;
        _hp = _hp <= _maxHp ? _hp : _maxHp;
    }

    public void GiveExp(int xp)
    {
        _exp += xp;

        // Check if we should level up.
        if (_exp >= _maxExp)
        {
            _level++;
            int extra = _exp - _maxExp;
            _exp = extra;
            _maxExp = (int)getMaxExp();
            _maxHp = (int)getMaxHp();
            _hp = _maxHp;

            _availableStats += 4;

            // Just incase we gained an insane amount of exp see if we leveled up again.
            GiveExp(0);
        }
    }

    public void DamagePlayer(int hp)
    {
        if (IsDead()) return;
        _hp -= hp;
        if (_hp <= 0)
        {
            PlayerController.getAnimations().Death(PlayerController.getAnimator());
            Debug.Log("Death");
            _hp = 0;
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        //yield on a new YieldInstruction that waits for .5 seconds.
        yield return new WaitForSeconds(3f);
        Debug.Log("Waited 3 seconds");
        // PlayerController.controller.Respawn();
        yield return new WaitForSeconds(1f);
        Debug.Log("Waited 1 seconds");
        _hp = (int) getMaxHp();
        PlayerController.getAnimations().Idle(PlayerController.getAnimator());
    }

    IEnumerator ExpTest()
    {
        DamagePlayer(10);
        //yield on a new YieldInstruction that waits for .5 seconds.
        yield return new WaitForSeconds(1f);

        if (IsDead()) yield break;
        StartCoroutine(ExpTest());
    }

    public float getHealthPercentage()
    {
        return (float)_hp / (float)_maxHp;
    }

    public float getExpPercentage()
    {
        return (float)_exp / (float)_maxExp;
    }

    public void addSta()
    {
        if (_availableStats > 0)
        {
            _availableStats--;
            _addSta++;
        }
    }

    public void addStr()
    {
        if (_availableStats > 0)
        {
            _availableStats--;
            _addStr++;
        }
    }

    public void addInt()
    {
        if (_availableStats > 0)
        {
            _availableStats--;
            _addInt++;
        }
    }

    public void addDex()
    {
        if (_availableStats > 0)
        {
            _availableStats--;
            _addDex++;
        }
    }

    public void subSta()
    {
        if (_addSta > 0)
        {
            _addSta--;
            _availableStats++;
        }
    }

    public void subStr()
    {
        if (_addStr > 0)
        {
            _addStr--;
            _availableStats++;
        }
    }

    public void subInt()
    {
        if (_addInt > 0)
        {
            _addInt--;
            _availableStats++;
        }
    }

    public void subDex()
    {
        if (_addDex > 0)
        {
            _availableStats++;
            _addDex--;
        }
    }

    public void ApplyStats()
    {
        _sta += _addSta;
        _str += _addStr;
        _int += _addInt;
        _dex += _addDex;

        _addSta = 0;
        _addStr = 0;
        _addInt = 0;
        _addDex = 0;

        _maxHp = (int)getMaxHp();
    }
}
