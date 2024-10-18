using System.Runtime.CompilerServices;
using Fire_Emblem_View;
using Fire_Emblem.Skills.Factory;


namespace Fire_Emblem.Skills;

public class SkillFactory {

    public static Skill CreateSkill(string skillName, View view)
    {
        switch (skillName)
        {
            case "Fair Fight":
                return new FairFight();
            case "Will to Win":
                return new WillToWin();
            case "Single-Minded":
                return new SingleMinded();
            case "Ignis":
                return new Ignis();
            case "Perceptive":
                return new Perceptive();
            case "Tome Precision":
                return new TomePrecision();
            case "Attack +6":
                return new AttackPlus6();
            case "Defense +5":
                return new DefensePlus5();
            case "Speed +5":
                return new SpeedPlus5();
            case "Atk/Def +5":
                return new AtkDefPlus5();
            case "Atk/Res +5":
                return new AtkResPlus5();
            case "Spd/Res +5":
                return new SpdResPlus5();
            case "Resistance +5":
                return new ResistancePlus5();
            case "Wrath":
                return new Wrath();
            case "Resolve":
                return new Resolve();
            case "Deadly Blade":
                return new DeadlyBlade();
            case "Death Blow":
                return new DeathBlow();
            case "Darting Blow":
                return new DartingBlow();
            case "Swift Sparrow":
                return new SwiftSparrow();
            case "Warding Blow":
                return new WardingBlow();
            case "Sturdy Blow":
                return new SturdyBlow();
            case "Mirror Strike":
                return new MirrorStrike();
            case "Steady Blow":
                return new SteadyBlow();
            case "Swift Strike":
                return new SwiftStrike();
            case "Bracing Blow":
                return new BracingBlow();
            case "Armored Blow":
                return new ArmoredBlow();
            case"Brazen Atk/Def":
                return new BrazenAtkDef();
            case "Brazen Atk/Res":
                return new BrazenAtkRes();
            case "Brazen Atk/Spd":
                return new BrazenAtkSpd();
            case "Brazen Spd/Res":
                return new BrazenSpdRes();
            case "Brazen Spd/Def":
                return new BrazenSpdDef();
            case "Brazen Spd/Ress":
                return new BrazenSpdRes();
            case "Brazen Def/Res":
                return new BrazenDefRes();
            case "Fire Boost":
                return new FireBoost();
            case "Earth Boost":
                return new EarthBoost();
            case "Water Boost":
                return new WaterBoost();
            case "Wind Boost":
                return new WindBoost();
            case "Chaos Style":
                return new ChaosStyle();
            case "HP +15":
                return new HpPlus15();
            case "Blinding Flash":
                return new BlindingFlash();
            case "Not *Quite*":
                return new NotQuite();
            case "Stunning Smile":
                return new StunningSmile();
            case "Charmer":
                return new Charmer();
            case "Luna":
                return new Luna();
            case "Disarming Sigh":
                return new DisarmingSigh();
            case "Belief in Love":
                return new BeliefInLove();
            case "Beorc's Blessing":
                return new BeorcsBlessing();
            case "Agnea's Arrow":
                return new AgneasArrow();
            case "Soulblade":
                return new SoulBlade();
            case "Sandstorm":
                return new SandStorm();
            case "Sword Agility":
                return new SwordAgility();
            case "Lance Power":
                return new LancePower();
            case "Sword Power":
                return new SwordPower();
            case "Bow Focus":
                return new BowFocus();
            case "Lance Agility":
                return new LanceAgility();
            case "Axe Power":
                return new AxePower();
            case "Bow Agility":
                return new BowAgility();
            case "Sword Focus":
                return new SwordFocus();
            case "Close Def":
                return new CloseDef();
            case "Distant Def":
                return new DistantDef();
            case "Lull Atk/Spd":
                return new LullAtkSpd();
            case "Lull Atk/Def":
                return new LullAtkDef();
            case "Lull Atk/Res":
                return new LullAtkRes();
            case "Lull Spd/Def":
            return new LullSpdDef();
            case "Lull Spd/Res":
                return new LullSpdRes();
            case "Lull Def/Res":
                return new LullDefRes();
            case "Fort. Def/Res":
                return new FortDefRes();
            case "Life and Death":
                return new LifeAndDeath();
            case "Solid Ground":
                return new SolidGround();
            case "Still Water":
                return new StillWater();
            case "Dragonskin":
                return new DragonSkin();
            case "Light and Dark":
                return new LightAndDark();
            //     case "Soulblade":
            //         return new SoulBlade();
            //     case "Sandstorm":
            //         return new SandStorm();
            //     case "HP +15":
            //         return new HPPlus15();
            //
            // Agrega más habilidades según sea necesario
            default:
                throw new ArgumentException("Skill not recognized: " + skillName);
        }
        // switch (skillName) {
        //     case "Armored Blow":
        //         return new ArmoredBlow();
        //     case "Fair Fight":
        //         return new FairFight();
        //     case "Will to Win":
        //         return new WillToWin();

        //     case "Ignis":
        //         return new Ignis();
        //     case "Perceptive":
        //         return new Perceptive();
        //     case "Tome Precision":
        //         return new TomePrecision();
        //     case "Attack +6":
        //         return new AttackPlus6();
        //     case "Atk/Def +5":
        //         return new AtkDefPlus5();
        //     case "Atk/Res +5":
        //         return new AtkResPlus5();
        //     case "Spd/Res +5":
        //         return new SpdResPlus5();
        //     case "Resistance +5":
        //         return new ResistancePlus5();
        //     case "Defense +5":
        //         return new DefensePlus5();
        //     case "Speed +5":
        //         return new SpeedPlus5();
        //     case "Wrath":
        //         return new Wrath();
        //     case "Resolve":
        //         return new Resolve();
        //     case "Deadly Blade":
        //         return new DeadlyBlade();
        //     case "Death Blow":
        //         return new DeathBlow();
        //     case "Darting Blow":
        //         return new DartingBlow();
        //     case "Swift Sparrow":
        //         return new SwiftSparrow();
        //     case "Warding Blow":
        //         return new WardingBlow();
        //     case "Sturdy Blow":
        //         return new SturdyBlow();
        //     case "Mirror Strike":
        //         return new MirrorStrike();
        //     case "Steady Blow":
        //         return new SteadyBlow();
        //     case "Swift Strike":
        //         return new SwiftStrike();
        //     case "Bracing Blow":
        //         return new BracingBlow();


        //     case "Chaos Style":
        //         return new ChaosStyle();
        //     case "Blinding Flash":
        //         return new BlindingFlash();
        //     case "Not *Quite*":
        //         return new NotQuite();
        //     case "Stunning Smile":
        //         return new StunningSmile();
        //     case "Disarming Sigh":
        //         return new DisarmingSigh();
        //     case "Charmer":
        //         return new Charmer();
        //     case "Luna":
        //         return new Luna();
        //     case "Belief in Love":
        //         return new BeliefInLove();


        //     case "Lance Power":
        //         return new LancePower();
        //     case "Sword Power":
        //         return new SwordPower();
        //     case "Sword Agility":
        //         return new SwordAgility();
        //     case "Bow Focus":
        //         return new BowFocus();
        //     case "Lance Agility":
        //         return new LanceAgility();
        //     case "Axe Power":
        //         return new AxePower();
        //     case "Bow Agility":
        //         return new BowAgility();
        //     case "Sword Focus":
        //         return new SwordFocus();
        //     case "Close Def":
        //         return new CloseDef();
        //     case "Distant Def":
        //         return new DistantDef();
        //     case "Lull Atk/Spd":
        //         return new LullAtkSpd();
        //     case "Lull Atk/Def":
        //         return new LullAtkDef();
        //     case "Lull Atk/Res":
        //         return new LullAtkRes();
        //     case "Lull Spd/Def":
        //         return new LullSpdDef();
        //     case "Lull Spd/Res":
        //         return new LullSpdRes();
        //     case "Lull Def/Res":
        //         return new LullDefRes();
        //     case "Fort. Def/Res":
        //         return new FortDefRes();
        //     case "Life and Death":
        //         return new LifeAndDeath();
        //     case "Solid Ground":
        //         return new SolidGround();
        //     case "Still Water":
        //         return new StillWater();
        //     case "Dragonskin":
        //         return new DragonSkin();
        //     case "Light and Dark":
        //         return new LightAndDark();
        //     case "Soulblade":
        //         return new SoulBlade();
        //     case "Sandstorm":
        //         return new SandStorm();
        //     case "HP +15":
        //         return new HPPlus15();
        //
        //     default:
        //         throw new ArgumentException("Skill not recognized" + skillName);
        // }
        
    }

    public static bool IsNewSkill(string skillName)
    {
        // Lista de nuevas habilidades
        string[] newSkills = {
            "Dragon Wall",
            "Gentility",
            "Dodge",
            "Golden Lotus",
            "Back at You",
            "Lunar Brace",
            "Bravery",
            "Bushido",
            "Moon-Twin Wing",
            "Blue Skies",
            "Aegis Shield",
            "Remote Sparrow",
            "Remote Mirror",
            "Remote Sturdy",
            "Fierce Stance",
            "Darting Stance",
            "Steady Stance",
            "Warding Stance",
            "Kestrel Stance",
            "Sturdy Stance",
            "Mirror Stance",
            "Steady Posture",
            "Swift Stance",
            "Bracing Stance",
            "Poetic Justice",
            "Laguz Friend",
            "Chivalry",
            "Dragon’s Wrath",
            "Prescience",
            "Extra Chivalry",
            "Guard Bearing",
            "Divine Recreation"
        };

        return Array.Exists(newSkills, skill => skill.Equals(skillName, StringComparison.OrdinalIgnoreCase));
    }
}
