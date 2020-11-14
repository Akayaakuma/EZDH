using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoctHelper
{
    public enum SkillName
    {
        //Dh
        Vengeance,//pixel
        FanOfKnives,//pixel
        Companion,//pixel
        Preparation,//pixel
        HungeringArrow,//pixelMEHR---------------------------------------
        //Necro
        LandOfTheDead,//pixel
        Simulacrum,//pixel
        SkeletalMage,//pixelMEHR---------------------------------------
        BoneArmor,//pixelMEHR---------------------------------------CDR
        CommandSkeletons,//time
        Devour,//time
        //Barb
        IgnorePain,//pixel / pixelMEHR---------------------------------------
        ThreateningShout,//pixel 
        BattleRage,//pixel
        WarCry,//pixel
        Sprint,//pixel
        Berserker,//pixel
        //Monk
        Sanctuary,//pixel
        Serenity,//pixel
        BlindingFlash,//pixel
        Epiphany,//pixel
        Mantra,//time
        BreathOfHeaven,//pixel
        //Krusi
        AkaratChampion,//pixel(irgendwann zu ablaufen ändern)
        Provoke,//pixel
        IronSkin,//pixel
        LawValor,//time
        LawJustice,//time
        LawHope,//time
        //Mage
        ArmoreIce,//pixel
        ArmoreStorm,//pixel
        ArmoreEnergy,//pixel
        Weapon,//pixel
        Familiar //pixel
    }

    public enum SkillType
    {
        ColorTrigger,
        AuslaufTrigger,
        TimeTrigger,
        Special
    }
    
    public class Skill
    {
        private SkillName sn;
        private SkillType type;
        private string name;
        private int x;
        private int y;
        private string c;
        private int time; // Delay in millis

        public Skill(SkillName skillName, SkillType skillType, string StringName, int xPos, int yPos, string color, int delayTime)
        {
            sn = skillName;
            type = skillType;
            name = StringName;
            x = xPos;
            y = yPos;
            c = color;
            time = delayTime;
        }

        public static List<Skill> AllSkills()
        {
            List<Skill> l = new List<Skill>();
            
            //standart
            l.Add(ColorSkillStandart(SkillName.Vengeance, "Vengeance", "#6C6C54"));
            l.Add(ColorSkillStandart(SkillName.FanOfKnives, "Fan Of Knives", "#6D6B54"));
            l.Add(ColorSkillStandart(SkillName.Companion, "Companion", "#6B6958"));
            l.Add(ColorSkillStandart(SkillName.Preparation, "Preparation", "#6E6855"));
            l.Add(ColorSkillStandart(SkillName.LandOfTheDead, "Land Of The Dead", "#6D6C54"));
            l.Add(ColorSkillStandart(SkillName.Simulacrum, "Simulacrum", "#6D6C55"));
            l.Add(ColorSkillStandart(SkillName.IgnorePain, "Ignore Pain", "#6D6C53"));
            l.Add(ColorSkillStandart(SkillName.ThreateningShout, "Threatening Shout", "#6C6C53"));
            l.Add(ColorSkillStandart(SkillName.BattleRage, "Battle age", "#6C6C54"));
            l.Add(ColorSkillStandart(SkillName.WarCry, "War Cry", "#6C6B54"));
            l.Add(ColorSkillStandart(SkillName.Sprint, "Sprint", "#6D6C54"));
            l.Add(ColorSkillStandart(SkillName.Berserker, "Berserker", "#666D54"));
            l.Add(ColorSkillStandart(SkillName.Sanctuary, "Sanctuary", "#71694C"));
            l.Add(ColorSkillStandart(SkillName.Serenity, "Serenity", "#6D6C54"));
            l.Add(ColorSkillStandart(SkillName.Epiphany, "Epiphany", "#6B6952"));
            l.Add(ColorSkillStandart(SkillName.BlindingFlash, "Blinding Flash", "#71684C"));
            l.Add(ColorSkillStandart(SkillName.BreathOfHeaven, "Breasth Of Heaven", "#716A4C"));
            l.Add(ColorSkillStandart(SkillName.AkaratChampion, "AkaratChampion", "#6C6B54"));
            l.Add(ColorSkillStandart(SkillName.Provoke, "Provoke", "#6E684F"));
            l.Add(ColorSkillStandart(SkillName.IronSkin, "Iron Skin", "#716A52"));
            l.Add(ColorSkillStandart(SkillName.ArmoreStorm, "Storm Armore ", "#60716F"));
            l.Add(ColorSkillStandart(SkillName.ArmoreIce, "Ice Armore ", "#7E634D"));
            l.Add(ColorSkillStandart(SkillName.ArmoreEnergy, "Energy Armore", "#6B6955"));
            l.Add(ColorSkillStandart(SkillName.Weapon, "Weapon", "#6C6B55"));
            l.Add(ColorSkillStandart(SkillName.Familiar, "Familiar", "#6D6B54"));
            //CDR
            
            //Timing
            l.Add(TimeSkill(SkillName.BoneArmor, "Bone Armor", 9000));
            l.Add(TimeSkill(SkillName.CommandSkeletons, "Command Skeletons", 500)); //ändern
            l.Add(TimeSkill(SkillName.Devour, "Devour", 100));
            l.Add(TimeSkill(SkillName.Mantra, "Mantra", 100));
            l.Add(TimeSkill(SkillName.LawValor, "LawValor", 2000));
            l.Add(TimeSkill(SkillName.LawJustice, "LawJustice", 2000));
            l.Add(TimeSkill(SkillName.LawHope, "LawHope", 2000));
            //Special
            //l.Add(SpecialSkill(SkillName.SkeletalMage, "Skeletal Mage"));
            l.Add(SpecialSkill(SkillName.HungeringArrow, "Hungering Arrow"));

            return l;
        }

        private static Skill ColorSkill(SkillName name, string sName, int x, int y, string c)
        {
            return new Skill(name, SkillType.ColorTrigger, sName, x, y, c, 0);
        }
        
        private static Skill ColorSkillStandart(SkillName name, string sName, string c)
        {
            return new Skill(name, SkillType.ColorTrigger, sName, 658, 1003, c, 0);
        }
        
        private static Skill AuslaufSkill(SkillName name, string sName, int x, int y)
        {
            return new Skill(name, SkillType.AuslaufTrigger, sName, x, y, "", 0);
        }

        private static Skill TimeSkill(SkillName name, string sName, int delayTime)
        {
            return new Skill(name, SkillType.TimeTrigger, sName, 658, 1003, "", delayTime);
        }

        private static Skill SpecialSkill(SkillName name, string sName)
        {
            return new Skill(name, SkillType.Special, sName, 658, 1003, "", 0);
        }

        public override string ToString()
        {
            return name;
        }

        public SkillName GetSkillName()
        {
            return sn;
        }

        public SkillType GetSkillType()
        {
            return type;
        }

        public string GetName()
        {
            return name;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public string GetColor()
        {
            return c;
        }

        public int GetDelayTime()
        {
            return time;
        }

    }
}

//Note:
// slot1: +0
// slot2: +66
// slot3: +133
// slot4: +200