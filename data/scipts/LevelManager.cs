using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "a7326492a0523ac9e1a9059495b133e3824607e6")]
public class LevelManager : Component
{
	public event Action endGameEvent;
	private int score;
	WidgetLabel widgetScoreText, widgetScore, endText;
	WidgetButton resetBut;

	private void Init()
	{
		score = 0;
		InitGUI();
	}
	
	private void Update()
	{
	
	}

	public void Win() {
		endText.Text = "You won!\nYour final score is " + score.ToString();
		endGame();
	}

	public void Loose() {
		endText.Text = "You feeeeeeeell!\nYour final score is " + score.ToString();
		endGame();
	}

	private void InitGUI()
	{
		Gui gui = Gui.Get();

		widgetScoreText = new WidgetLabel(gui, "Score:");
		widgetScoreText.SetPosition(10, 10);
		widgetScoreText.FontColor = vec4.RED;
		widgetScoreText.FontSize = 50;

		widgetScore = new WidgetLabel(gui, "0");
		widgetScore.SetPosition(170, 10);
		widgetScore.FontColor = vec4.BLUE;
		widgetScore.FontSize = 50;

		endText = new WidgetLabel(gui, "");
		endText.SetPosition(gui.Width / 4, gui.Height / 4 + 30);
		endText.FontColor = vec4.GREEN;
		endText.FontSize = 100;
		endText.Hidden = true;

		resetBut =  new WidgetButton(gui, "Restart");
		resetBut.SetPosition(gui.Width / 4 + 100, gui.Height / 4 + 220);
		resetBut.AddCallback(Gui.CALLBACK_INDEX.CLICKED, ResetClick);
		resetBut.FontSize = 100;
		resetBut.Hidden = true;
		resetBut.Enabled = false;

		// add widgets to the GUI
		gui.AddChild(widgetScoreText, Gui.ALIGN_OVERLAP);
		gui.AddChild(widgetScore, Gui.ALIGN_OVERLAP);
		gui.AddChild(endText, Gui.ALIGN_OVERLAP);
		gui.AddChild(resetBut, Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);
	}

	public void addScore(int points) {
		score += points;
		widgetScore.Text = score.ToString();
	}

	private void endGame() {
		widgetScore.Enabled = false;
		widgetScoreText.Enabled = false;
		widgetScore.Hidden = true;
		widgetScoreText.Hidden = true;
		endText.Hidden = false;
		resetBut.Hidden = false;
		resetBut.Enabled = true;
		endGameEvent?.Invoke();
	}

	private void ResetClick() {
		score = 0;
		endText.Hidden = true;
		resetBut.Hidden = true;
		resetBut.Enabled = false;
		Unigine.Console.Run("world_reload");
	}
}