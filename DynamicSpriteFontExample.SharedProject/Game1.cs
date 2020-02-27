using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;

namespace DynamicSpriteFontExample
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager _graphics;
		SpriteBatch _spriteBatch;
		private DynamicSpriteFont _font;
		private int _fontIdJapanese, _fontIdEmojis;
		private Texture2D _white;
		private bool _drawBackground = false;
		private bool _wasSpaceDown;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = 1200,
				PreferredBackBufferHeight = 800
			};

			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			Window.AllowUserResizing = true;
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			_font = DynamicSpriteFont.FromTtf(Content.Load<byte[]>(@"LuckiestGuy-Regular"), 72, 512, 512);
			_fontIdJapanese = _font.AddTtf("Japanese", Content.Load<byte[]>(@"LuckiestGuy-Regular"));
			_fontIdEmojis = _font.AddTtf("Emojis", Content.Load<byte[]>(@"LuckiestGuy-Regular"));

			//_font = DynamicSpriteFont.FromTtf(Content.Load<byte[]>(@"DroidSans"), 72);
			//_fontIdJapanese = _font.AddTtf("Japanese", Content.Load<byte[]>(@"DroidSansJapanese"));
			//_fontIdEmojis = _font.AddTtf("Emojis", Content.Load<byte[]>(@"Symbola-Emoji"));

			_white = new Texture2D(GraphicsDevice, 1, 1);
			_white.SetData(new[] { Color.White });

			GC.Collect();
		}

		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			var state = Keyboard.GetState();

			var isSpaceDown = state.IsKeyDown(Keys.Space);

			if (isSpaceDown && !_wasSpaceDown)
			{
				_drawBackground = !_drawBackground;
			}

			_wasSpaceDown = isSpaceDown;
		}

		private void DrawString(string text, int y, Color color, float scale = 1f)
		{
			if (_drawBackground)
			{
				var size = _font.MeasureString(text);
				_spriteBatch.Draw(_white, new Rectangle(0, y, (int)size.X, (int)size.Y), Color.Green);
			}

			_spriteBatch.DrawString(_font, text, new Vector2(0, y), color, new Vector2(scale));
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			_spriteBatch.Begin();

			_font.FontId = _font.DefaultFontId;
			// Render some text
			//_font.Size = 18;
			//DrawString("The quick brown fox jumps over the lazy dog", 0);
			_font.Size = 24;
			DrawString("Loading...", 0, Color.White);

			DrawString("Loading...", 0, Color.Red);


			//_font.Size = 64;

			DrawString("The quick brown fox jumps over the lazy dog", 64, Color.White, 2f);

			//_font.Size = 20;
			DrawString("Üben quält finſteren Jagdſchloß höfliche Bäcker größeren, N: Blåbærsyltetøy", 30, Color.White, 3f);

			//_font.Size = 22;
			DrawString("Høj bly gom vandt fræk sexquiz på wc, S: bäckasiner söka", 60, Color.White);

			//_font.Size = 24;
			DrawString("Sævör grét áðan því úlpan var ónýt, P: Pchnąć w tę łódź jeża lub osiem skrzyń fig", 90, Color.White);

			//_font.Size = 26;
			DrawString("Příliš žluťoučký kůň úpěl ďábelské kódy, R: В чащах юга жил-был цитрус? Да, но фальшивый экземпляр! ёъ.", 120, Color.White);

			//_font.Size = 28;
			DrawString("kilómetros y frío, añoraba, P: vôo à noite, F: Les naïfs ægithales hâtifs pondant à Noël où", 150, Color.White);

			_font.FontId = _fontIdJapanese;
			//_font.Size = 30;
			DrawString("いろはにほへど", 180, Color.White);

			_font.FontId = _fontIdEmojis;
			//_font.Size = 32;
			DrawString("🙌📦👏🔥👍😻😂🎉💻😍🚀😁🙈🇧🇪👩😉🍻🎶🏆👀👉👶💕😎😱🌌🌻🍺🏀👇👯💁💝💩😃😅🙏🚄🇫🌧🌾🍀🍁🍓🍕🎾🏈", 220, Color.White);

			_font.FontId = _font.DefaultFontId;
			//_font.Size = 26;
			DrawString("Texture:", 300, Color.White);

			_spriteBatch.Draw(_font.Texture, new Vector2(0, 330), Color.White);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}