#if false

using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;
using UnityEditor;
using UnityEngine;
using GameAnalyticsSDK;

namespace HutongGames.PlayMakerEditor
{
    [CustomActionEditor(typeof (SendProgressionEvent))]
	public class SendProgressionEventActionEditor : CustomActionEditor
    {
		
        public override bool OnGUI()
        {
			bool edited = false;
			SendProgressionEvent _target = (SendProgressionEvent)target;
			
			if (_target.ProgressionStatusAsString == null)
			{
				_target.ProgressionStatusAsString = new HutongGames.PlayMaker.FsmString(){ UseVariable=false };
			}
			
			if (_target.ProgressionStatusAsString.UseVariable)
			{
				EditField("ProgressionStatusAsString");
					
			}
			else
			{
				GUILayout.BeginHorizontal();
				_target.ProgressionStatus = (GA_Progression.GAProgressionStatus)EditorGUILayout.EnumPopup("Progression Status", _target.ProgressionStatus);
				
				if (PlayMakerEditor.FsmEditorGUILayout.MiniButtonPadded(PlayMakerEditor.FsmEditorContent.VariableButton))
				{
					_target.ProgressionStatusAsString.UseVariable = true;
				}
				GUILayout.EndHorizontal();
			}

			EditField("Progression01");

			if (_target.Progression01.Value != "")
				EditField("Progression02");

			if (_target.Progression02.Value != "")
				EditField("Progression03");

			return GUI.changed || edited;
        }

    }
}

#endif