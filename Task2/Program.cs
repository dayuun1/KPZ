using System;

abstract class Hero
{
    public abstract string GetName();
    public abstract int GetPower();
    public abstract int GetHP();
}

class Warrior : Hero
{
    public override string GetName()
    {
        return "Warrior";
    }

    public override int GetPower()
    {
        return 20;
    }

    public override int GetHP()
    {
        return 200;
    }
}

class Mage : Hero
{
    public override string GetName()
    {
        return "Mage";
    }

    public override int GetPower()
    {
        return 15;
    }

    public override int GetHP()
    {
        return 150;
    }
}

class Paladin : Hero
{
    public override string GetName()
    {
        return "Paladin";
    }

    public override int GetPower()
    {
        return 18;
    }

    public override int GetHP()
    {
        return 180;
    }
}

abstract class Inventory : Hero
{
    protected Hero hero;

    public Inventory(Hero hero)
    {
        this.hero = hero;
    }

    public override string GetName()
    {
        return hero.GetName();
    }

    public override int GetPower()
    {
        return hero.GetPower();
    }

    public override int GetHP()
    {
        return hero.GetHP();
    }
}

class Sword : Inventory
{
    public Sword(Hero hero) : base(hero) { }

    public override string GetName()
    {
        return hero.GetName() + " with a sword";
    }

    public override int GetPower()
    {
        return hero.GetPower() + 10;
    }
}

class Armor : Inventory
{
    public Armor(Hero hero) : base(hero) { }

    public override string GetName()
    {
        return hero.GetName() + " with armor";
    }

    public override int GetHP()
    {
        return hero.GetHP() + 20;
    }
}

class Amulet : Inventory
{
    public Amulet(Hero hero) : base(hero) { }

    public override string GetName()
    {
        return hero.GetName() + " with amulet";
    }

    public override int GetPower()
    {
        return hero.GetPower() + 10;
    }

    public override int GetHP()
    {
        return hero.GetHP() + 10;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Hero hero = new Paladin();
        Console.WriteLine($"{hero.GetName()} has {hero.GetPower()} power and {hero.GetHP()} HP");

        hero = new Sword(hero);
        hero = new Armor(hero);
        hero = new Amulet(hero);

        Console.WriteLine($"{hero.GetName()} has {hero.GetPower()} power and {hero.GetHP()} HP");
    }
}