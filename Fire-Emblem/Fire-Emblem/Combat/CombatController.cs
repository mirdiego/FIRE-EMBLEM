// using Fire_Emblem_View;
// using System.Collections.Generic;
//
// namespace Fire_Emblem;
//
// public class CombatController
// {
//     private readonly Combat _combat;
//     private readonly View _view;
//     private readonly Output _output;
//     private readonly SkillController _skillController;
//     private readonly AttackController _attackController;
//     private List<string> _attackTypes;
//
//     public CombatController(Combat combat, View view, Output output)
//     {
//         _combat = combat;
//         _view = view;
//         _output = output;
//         _attackTypes = new List<string> { "first attack", "counter attack", "first follow up", "second follow up", "finished combat" };
//
//         _skillController = new SkillController(_combat);
//         _attackController = new AttackController(_combat, _view);
//     }
//
//     public void PrepareRound(View view)
//     {
//         _skillController.PrepareSkills(view);
//         _combat.Attacker.SetCombat(_combat, _view);
//         _combat.Defender.SetCombat(_combat, _view);
//         _skillController.CheckConditions(view);
//     }
//
//     public void StartRound()
//     {
//         while (_attackTypes[_combat.AttackPosition] != "finished combat")
//         {
//             switch (_attackTypes[_combat.AttackPosition])
//             {
//                 case "first attack":
//                     _attackController.PerformAttack();
//                     break;
//                 case "counter attack":
//                     _attackController.PerformAttack();
//                     break;
//                 case "first follow up":
//                     _attackController.PerformFirstFollowUp();
//                     break;
//                 case "second follow up":
//                     _attackController.PerformSecondFollowUp();
//                     break;
//             }
//         }
//     }
//
//     public void FinalizeCombat()
//     {
//         if (!_attackController.FirstHasFollowUp() && !_attackController.SecondHasFollowUp() && _combat.Winner == null)
//         {
//             _output.SaveFollowUpMessage();
//         }
//
//         // Ahora establece los oponentes finales
//         _combat.SetAsLastOpponents();
//         _output.SaveResult(_combat);
//         _output.PrintRound(_view);
//     }
// }
