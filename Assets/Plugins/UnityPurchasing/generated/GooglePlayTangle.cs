#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("SiUoN2JXruoqE7xUyfpYQH9eHStImx8rDtJQsdny1pJn+LBqZ94ik9dl5sXX6uHuzWGvYRDq5ubm4ufkouvGfG1bXGgtZicudu/AMLuThPvqISXyCCqP/0NLBp2EV+hDVxs1isAKskhtsDrwVvq2FKXC/tfteDWGR18dgNT1R5u19TblVZhbIv6m/MnbT9p+KOchUFc4gOtx+Y3i3UN+GdL4biAFpGYxxaQ05lIgQpBg/1pxZebo59dl5u3lZebm52XlWtv7xqG/zVkAesCgjP9pqS38jaIw4QCF6SIvQDoXGTFxnpkyAq587RiP4Se7u/PDf4x9oNs5LqQUvHqS/zmX83KQXQDJihReYu/N6cnwmsSpklAEnTPKfetY3K68MuXk5ufm");
        private static int[] order = new int[] { 2,11,2,10,7,13,6,8,13,11,12,13,13,13,14 };
        private static int key = 231;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
