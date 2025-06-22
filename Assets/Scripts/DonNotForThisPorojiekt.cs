using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Privet 
{

    public class DonNotForThisPorojiekt : MonoBehaviour
    {
        public DissatisfiedWeapon weapon = new Axe("UssialAxe");
        public Axe axe = new("objAxe");
        public EnemyMain main = new EnemyMain();

        void Start()
        {
            Debug.Log(weapon is Axe axe2 ? weapon.TypeOfDamage + axe2.Name : "мнд");
            DissatisfiedWeapon weapon2 = new Sword("UltraSword");
            Sword s = weapon2 as Sword;
            Debug.Log(weapon2.TypeOfDamage + s?.Name);
            

            EnemyBase enemy = new Dragon("DDragon");
            EnemyBase enemy1 = new Vampire("VVampire");
            EnemyBase enemy2 = new Zombie("ZZombie");
            main.AddEnemy<Dragon>(enemy);
            main.AddEnemy<Vampire>(enemy1);
            main.AddEnemy<Zombie>(enemy2);
            EnemyBase enemy3 = main.GetEnemyFromDictionary<Dragon>();
            EnemyBase enemy4 = main.GetEnemyFromDictionary<Vampire>();
            EnemyBase enemy5 = main.GetEnemyFromDictionary<Zombie>();
            Debug.Log(enemy3.name);
            Debug.Log(enemy4.name);
            Debug.Log(enemy5.name);
        }
    }
    public class DissatisfiedWeapon
    {
        public string TypeOfDamage = "dissatisfied";
    }
    public class Axe : DissatisfiedWeapon
    {
        public Axe(string Name)
        {
            this.Name = Name;
        }
        public string Name;
    }
    public class Sword : DissatisfiedWeapon
    {
        public Sword(string Name)
        {
            this.Name = Name;
        }
        public string Name;
    }

    public abstract class EnemyBase
    {
        public string name;
        public  EnemyBase(string name)
        {
            this.name = name;
        }
       
    }
    public class Zombie : EnemyBase
    {
        public  Zombie(string name) : base(name)
        {
        }
    }
    public class Vampire : EnemyBase
    {
        public Vampire(string name) : base(name)
        {
        }
    }
    public class Dragon : EnemyBase
    {
        public Dragon(string name) : base(name)
        {
        }
    }
    public class EnemyMain
    {
        public readonly Dictionary<Type, EnemyBase> enemys = new();
        public void AddEnemy<T>(EnemyBase enemy)
        {
            enemys.Add(typeof(T),    enemy);
        }

        public T GetEnemyFromDictionary<T>() where T : EnemyBase
        {
            if (enemys.TryGetValue(typeof(T), out var currentEnemy))
                return currentEnemy as T;
            else return null;
        }

    }
}