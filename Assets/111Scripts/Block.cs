// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Nethereum.RPC.Eth.DTOs;
// using Org.BouncyCastle.Utilities;
// using UnityEngine;
// using Object = System.Object;
//
// public class Block : MonoBehaviour
// {
//     private int previousHash;
//     private String[] transactions;
//     private int blockHash;
//     
//     HashSet<int> evenNumbers = new HashSet<int>();
//     HashSet<int> oddNumbers = new HashSet<int>();
//
//     public Block(int previousHash, String[] transactions)
//     {
//         this.previousHash = previousHash;
//         this.transactions = transactions;
//         //
//         HashCode hashCode = new HashCode();
//         
//         //Object[] contents = {Arrays.HashCode(transactions), previousHash };
//         // this.blockHash = Array.hashCode(contents);
//         
//         
//         Hashtable table = new Hashtable();
//         
//
//
//
//     }
//
//     public void Start()
//     {
//         int[] intArray = CreateArray<int>(5, 6);
//
//         CreateArray<int>(5, 4);
//         
//         //Debug.Log(intArray.Length + "" + intArray[0] + "" + intArray[1]);
//     }
//
//     private T[] CreateArray<T>(T firstElement, T secondElement)
//     {
//         return new T[] { firstElement, secondElement };
//     }
//
//     public void Update()
//     {
//         for (int i = 0; i < 5; i++)
//         {
//             // Populate numbers with just even numbers.
//             evenNumbers.Add(i * 2);
//
//             // Populate oddNumbers with just odd numbers.
//             oddNumbers.Add((i * 2) + 1);
//         }
//         
//         // Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
//         Debug.Log(evenNumbers);
//
//         // Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
//         Debug.Log(oddNumbers);
//     }
//
//     public int getPreviousHash()
//     {
//         return previousHash;
//     }
//     
//     public String[] getTransactions()
//     {
//         return transactions;
//     }
//     
// }
