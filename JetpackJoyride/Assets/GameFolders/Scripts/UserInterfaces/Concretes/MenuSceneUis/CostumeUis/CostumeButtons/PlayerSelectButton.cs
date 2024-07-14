using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.CostumeUis.CostumeButtons
{
    public class PlayerSelectButton : BaseButton
    {
        [SerializeField] public PlayerDetailSO _playerDetailSO;
        [SerializeField] Image _selectionImage;
        public System.Action<PlayerSelectButton> onClick;
        private PlayerManager playerManager;

        public void Initialize(PlayerManager manager)
        {
            playerManager = manager;
        }
        protected override void ButtonOnClick()
        {
            onClick?.Invoke(this);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new ColorConverter());
            string playerDetailJson = JsonConvert.SerializeObject(_playerDetailSO, settings);
            PlayerPrefs.SetString("SelectedPlayer", playerDetailJson);
            PlayerPrefs.Save();

        }

        public void SetDefaultColor()
        {
            SetColorImage(Color.black);
        }
        public void SetSelectionColor()
        {
            SetColorImage(Color.yellow);
        }
        private void SetColorImage(Color color)
        {
            _selectionImage.color = color;
        }




    }

}
public class ColorConverter : JsonConverter<Color>
{
    public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
    {
        JObject colorObject = new JObject
        {
            { "r", value.r },
            { "g", value.g },
            { "b", value.b },
            { "a", value.a }
        };
        colorObject.WriteTo(writer);
    }

    public override Color ReadJson(JsonReader reader, System.Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject colorObject = JObject.Load(reader);
        float r = colorObject["r"].Value<float>();
        float g = colorObject["g"].Value<float>();
        float b = colorObject["b"].Value<float>();
        float a = colorObject["a"].Value<float>();
        return new Color(r, g, b, a);
    }
}