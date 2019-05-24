#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class AppleTangle
    {
        private static byte[] data = System.Convert.FromBase64String("PiMsIykrPi9qKDNqKyQzajorOD5qJSxqPiIvaj4iLyRqKzo6JiMpK/9w575FRErYQftrXGQ+n3ZHkShcYMwCzL1HS0tPT0p6KHtBekNMSR86Ji9qGCUlPmoJC3pUXUd6fHp+ePt6EqYQTnjGIvnFV5QvObUtFC/2MHrISzx6RExJH1dFS0u1Tk5JSEtMekVMSR9XWUtLtU5PeklLS7V6V8hLSkxDYMwCzL0pLk9Lesu4emBMxTnLKoxREUNl2PiyDgK6KnLUX7/0vjnRpJguRYEzBX6S6HSzMrUhgkIUeshLW0xJH1dqTshLQnrIS056E+1PQzZdChxbVD6Z/cFpcQ3pnyVCYUxLT09NSEtcVCI+Pjo5cGVlPUdMQ2DMAsy9R0tLT09KSchLS0oWT0pJyEtFSnrIS0BIyEtLSq7b40Pf1DBG7g3BEZ5cfXmBjkUHhF4jmyYvagMkKWR7bHpuTEkfTkFZVws6M2orOTk/Jy85aispKS86PiskKS8jLCMpKz4jJSRqCz8+IiU4Iz4ze4NTOL8XRJ81FdG4b0nwH8UHF0e7Rdd3uWEDYlCCtIT/80STFFacgXckLmopJSQuIz4jJSQ5aiUsaj85L0xJH1dETlxOXmGaIw3ePEO0viHHfNMGZzL9p8bRlrk90bg8mD16BYstxUL+ar2B5mZqJTr8dUt6xv0JhVx6XkxJH05JWUcLOjomL2oYJSU+ZArsvQ0HNUIUelVMSR9XaU5Selxsem5MSR9OQVlXCzo6Ji9qCS84PhgvJiMrJCkvaiUkaj4iIzlqKS84OCspPiMpL2o5Pis+LycvJD45ZHrh6TvYDRkfi+VlC/mysak6h6zpBk5MWUgfGXtZeltMSR9OQFlACzo6TaY3c8nBGWqZco779dAFQCG1YbY+IiU4Iz4ze1x6XkxJH05JWUcLOlXbkVQNGqFPpxQzzmehfOgdBh+m/VH32QhuWGCNRVf8B9YUKYIByl1Vz8nPUdN3DX2449EKxGae+9pYkmZqKS84PiMsIykrPi9qOiUmIykzOiYvagkvOD4jLCMpKz4jJSRqCz8PNFUGIRrcC8OOPihBWskLzXnAywOSPNV5Xi/rPd6DZ0hJS0pL6chLaiskLmopLzg+IywjKSs+IyUkajriljRof4Bvn5NFnCGe6G5pW73r5speYZojDd48Q7S+IcdkCuy9DQc1d2wtasB5IL1HyIWUoellsxkgES6TfDWLzR+T7dPzeAixkp871DTrGD09ZCs6OiYvZCklJ2UrOjomLykreshO8XrISenqSUhLSEhLSHpHTENqCQt6yEtoekdMQ2DMAsy9R0tLS8FTw5SzASa/TeFoekiiUnSyGkOZZXrLiUxCYUxLT09NSEh6y/xQy/kuf2lfAV8TV/nevbzW1IUa8IsSGoopeT29cE1mHKGQRWtEkPA5UwX/eXwQeih7QXpDTEkfTkxZSB8Ze1l/eHt+enl8EF1HeX96eHpzeHt+eigmL2o5PiskLis4Lmo+LzgnOWorbqihm/06lUUPq22Auycyp63/XV01C+LSs5uALNZuIVua6fGuUWCJVXpbTEkfTkBZQAs6OiYvagMkKWR7GuDAn5CutppDTX36Pz9r");
        private static int[] order = new int[] { 39,41,23,41,6,26,28,29,34,55,50,33,52,35,47,47,18,41,40,33,33,22,43,30,48,43,52,31,50,38,46,48,46,51,52,47,59,49,44,50,43,48,45,54,46,56,58,59,50,59,54,59,59,57,59,58,56,57,59,59,60 };
        private static int key = 74;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
