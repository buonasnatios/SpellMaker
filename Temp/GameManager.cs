using System;
using System.Collections.Generic;
using Godot;
using SpellMaker.Data.Enums;
using SpellMaker.Data.Invocations;
using SpellMaker.Data.Invocations.Additives;
using SpellMaker.Data.Invocations.Adjective;
using SpellMaker.Data.Invocations.Descriptors;
using SpellMaker.Data.Invocations.Nouns;
using SpellMaker.Data.Invocations.Verbs;

namespace SpellMaker;

public partial class GameManager : Node2D
{
	public List<IInvocation> Invocations = new();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var topVerbs = 150;
		var topAdjectives = 150;
		var topNouns = 150;
		var topDescriptors = 150;
		var topAdditives = 150;
		const int leftVerbs = 50;
		const int leftAdjectives = 150;
		const int leftNouns = 250;
		const int leftDescriptors = 350;
		const int leftAdditives = 450;
		RegisterInvocations(Invocations);
		foreach (var invocation in Invocations)
		{
			var button = new Button();
			button.Text = invocation.Name;
			switch (invocation.InvocationType)
			{
				case InvocationType.Noun:
					button.SetPosition(new Vector2(leftNouns,topNouns));
					topNouns += (int)button.Size.Y + 2;
					break;
				case InvocationType.Verb:
					button.SetPosition(new Vector2(leftVerbs,topVerbs));
					topVerbs += (int)button.Size.Y + 2;
					break;
				case InvocationType.Adjective:
					button.SetPosition(new Vector2(leftAdjectives,topAdjectives));
					topAdjectives += (int)button.Size.Y + 2;
					break;
				case InvocationType.Descriptor:
					button.SetPosition(new Vector2(leftDescriptors,topDescriptors));
					topDescriptors += (int)button.Size.Y + 2;
					break;
				case InvocationType.Additive:
					button.SetPosition(new Vector2(leftAdditives,topAdditives));
					topAdditives += (int)button.Size.Y + 2;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			button.Pressed += InvocationPressed;
			AddChild(button); 
		}
	}

	private void InvocationPressed()
	{
		GD.Print("Test");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
		
	private void RegisterInvocations(ICollection<IInvocation> invocations)
	{
		//Additives
		invocations.Add(new With());
		
		//Adjective
		invocations.Add(new Big());
		invocations.Add(new Lasting());
		invocations.Add(new Multiple());
		invocations.Add(new Small());
		invocations.Add(new Stunning());
		
		//Descriptors
		invocations.Add(new Arrow());
		invocations.Add(new Ball());
		invocations.Add(new Bolt());
	
		//Nouns
		invocations.Add(new Flame());
		invocations.Add(new Heal());
		invocations.Add(new Rock());
		invocations.Add(new Water());

		//Verbs
		invocations.Add(new Throw());
		invocations.Add(new Touch());
	}
}