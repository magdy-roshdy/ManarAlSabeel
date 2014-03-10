using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ManarAlSabeel.Web.Infrastructure
{
	public class SecurityHelper
	{
		public static string ComputeHash(string plainText, byte[] saltBytes = null, string hashAlgorithm = "")
		{
			if (saltBytes == null)
			{
				int saltSize = new Random().Next(4, 8);
				saltBytes = new byte[saltSize];
				new RNGCryptoServiceProvider().GetNonZeroBytes(saltBytes);
			}

			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];
			
			for (int i = 0; i < plainTextBytes.Length; i++)
				plainTextWithSaltBytes[i] = plainTextBytes[i];

			// Append salt bytes to the resulting array.
			for (int i = 0; i < saltBytes.Length; i++)
				plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

			HashAlgorithm hash = null;

			switch (hashAlgorithm.ToUpper())
			{
				case "SHA384":
					hash = new SHA384Managed();
					break;
				case "SHA512":
					hash = new SHA512Managed();
					break;
				default:
					hash = new MD5CryptoServiceProvider();
					break;
			}

			byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
			byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];
			for (int i = 0; i < hashBytes.Length; i++)
				hashWithSaltBytes[i] = hashBytes[i];

			// Append salt bytes to the result.
			for (int i = 0; i < saltBytes.Length; i++)
				hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

			return Convert.ToBase64String(hashWithSaltBytes);
		}

		public static bool VerifyHash(string plainText, string hashValue, string hashAlgorithm = "")
		{
			byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

			int hashSize;

			switch (hashAlgorithm.ToUpper())
			{

				case "SHA384":
					hashSize = 384 / 8;
					break;

				case "SHA512":
					hashSize = 512 / 8;
					break;

				default: //MD5
					hashSize = 128 / 8;
					break;
			}

			if (hashWithSaltBytes.Length < hashSize)
				return false;

			byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSize];

			// Copy salt from the end of the hash to the new array.
			for (int i = 0; i < saltBytes.Length; i++)
				saltBytes[i] = hashWithSaltBytes[hashSize + i];

			string expectedHashString = ComputeHash(plainText, saltBytes, hashAlgorithm);
			return (hashValue == expectedHashString);
		}
	}
}