﻿using System;
using System.Windows;
using System.Windows.Input;
using DamageMeter.Skills.Skill.SkillDetail;
using Data;
using Tera.Game;

namespace DamageMeter.UI.SkillDetail
{
    /// <summary>
    ///     Logique d'interaction pour SkillContent.xaml
    /// </summary>
    public partial class SkillDetailMana
    {
        public SkillDetailMana(SkillDetailStats skill)
        {
            InitializeComponent();
            Update(skill);
        }

        public void Update(SkillDetailStats skill)
        {
            //TODO Need to refactor this shitty copy paste shit
            var userskill = BasicTeraData.Instance.SkillDatabase.Get(new UserEntity(skill.PlayerInfo.Player.User.Id), skill.Id);
            bool? chained = false;
            string hit = null;
            if (userskill != null)
            {
                hit = ((UserSkill)userskill).Hit;
                chained = userskill.IsChained;
            }
            if (hit == null)
            {
                if (BasicTeraData.Instance.HotDotDatabase.Get(skill.Id) != null)
                {
                    hit = "MOT";
                }
            }
            if (hit != null)
            {
                LabelName.Content = hit;
            }
            if (chained == true)
            {
                LabelName.Content += " Chained";
            }

            LabelId.Content = skill.Id;
            LabelNumberHitMana.Content = skill.HitsMana;
            LabelTotalMana.Content = FormatHelpers.Instance.FormatValue(skill.Mana);
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            var w = Window.GetWindow(this);
            try
            {
                w?.DragMove();
            }
            catch
            {
                Console.WriteLine(@"Exception move");
            }
        }
    }
}