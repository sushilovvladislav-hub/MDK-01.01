using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;

namespace Simple_Game
{
    internal class AssetsManager : IDisposable
    {
        private readonly Dictionary<string, Bitmap> textures;
        private  Bitmap missingTexture;

        public AssetsManager() 
        {
            textures = new Dictionary<string, Bitmap>();

            Debug.WriteLine("AssetsManager: начало загрузки ресурсов");

            LoadAllTextures();

            Debug.WriteLine($"AssetsManager: загружено {textures.Count} текстур");


        }

        public Bitmap GetTexture(string name) 
        {
            if (textures.ContainsKey(name))
            {
                return textures[name];
            }

            Debug.WriteLine($"Текстура {name} не найдена! Используется заглушка.");
            
            return GetMissingTexture();
        }

        public void Dispose() 
        {
            Debug.WriteLine("AssetsManager: освобождение ресурсов.");

            foreach (var texture in textures.Values)
            {
                    texture?.Dispose();
            }

            textures.Clear();
            missingTexture?.Dispose();

            Debug.WriteLine("AssetsManager: ресурсы освобождены");
        }

        private Bitmap GetMissingTexture() 
        {
            if (missingTexture == null)
            {
                missingTexture = new Bitmap(64, 64);
                using (var g = Graphics.FromImage(missingTexture)) 
                {
                    g.Clear(Color.Fuchsia);
                }
                Debug.WriteLine("Создана заглушка.");
            }

            return missingTexture;
        }
        
        private void LoadAllTextures() 
        {
            LoadTexture("Road", Properties.Resources.newRoad);
            LoadTexture("Grass", Properties.Resources.newGrass);
            LoadTexture("PlayerCar", Properties.Resources.newCar);
            LoadTexture("Sky", Properties.Resources.newSky);
        }

        private void LoadTexture(string name, Bitmap texture) 
        {
            if (texture != null)
            {
                textures[name] = texture;
                Debug.WriteLine($"{name}: {texture.Width}x{texture.Height}");
            }
            else 
            {
                Debug.WriteLine($"{name}: Текстура отсутствует в Resources!");
            }
        }

    }
}
