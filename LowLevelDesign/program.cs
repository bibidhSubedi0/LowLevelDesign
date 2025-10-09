using LowLevelDesign.DesignPatterns.Behavioural.Strategy;



Character ch =  new Character();
ch.Attack();
ch.Emote();
ch.SetAttack(new SwordAttack());
ch.Attack();
ch.SetAttack(new MagicAttack());
ch.Attack();
ch.Emote();
