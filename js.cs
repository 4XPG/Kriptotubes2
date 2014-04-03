using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kriptotubes2
{
    class js
    {
		
		private byte[] copy(byte[] x){
		//fungsi untuk melakukan copy variabel byte.
		
			byte[] temp = new byte[x.Length];
			for(int i=0;i<x.Length;i++){
				temp[i]=x[i];
			}
			
			return temp;
		}
		
		private byte[] varXOR(byte[] a, byte[] b){
		//1. fungsi untuk melakukan XOR dua variabel.
		//2. asumsi panjang a dan b sama.
		
			byte[] temp = new byte[a.Length];
			for(int i=0;i<a.Length;i++){
				temp[i]=(byte)(a[i]^b[i]);
			}
			
			return temp;		
		}
				
		private byte[] findIO(byte[] key){
		//Fungsi untuk mencari I0
		
			int x=0;
			byte[] temp1, temp2, temp3;
			
			do{				
				//belum tw cara bagi dua
				temp1 = key.substring(0,key.Length/2);
				temp2 = key.substring(x,key.Length);
				
				//melakukan XOR dua variabel tsb
				temp3 = varXOR(temp1, temp2);
				
				//jika panjang key baru telah <= 8, maka diberi tanda sudah selesai beroperasi
				if(temp3.Length<=8){
					x=1;
				}		
				
			}while(x==0);	//x==0 jika panjang hasil XOR masih di atas 8
			
			//melengkapi panjang key jika kurang dari 8
			//menambahkan nilai 0 di belakang key hingga panjang key mencapai 8
			while(temp3.Length<7){
				//selalu menambahkan nilai 0 di belakang hingga panjang key mencukupi
				temp3[temp3.Length+1]=0;
			}
			
			//mengembalikan temp3 sebagai I0
			return temp3;
		}
		
		//========================================================================
		//========================================================================		
		
		private String EBC(String key, String text){
		//mode enkripsi EBC
		//asumsi
		//1. panjang key = 8
		//2. panjang text merupakan kelipatan 8
		
			int a,b,c;
			int size;
			String temp = String.Empty;
			String keyGen = String.Empty;
			String result = String.Empty;
			
			a=0;	//count jumlah char
			b=0;	//count jumlah penggunaan key
			while(a<text.Length){
				temp = text.substring(a,8);
				
				//generate fungsi key
				//key akan di-generate berdasarkan jumlah penggunaan kunci,
				//key juga akan di-reversi jika telah melakukan 5 penggunaan
				keyGen = generatorKey(key,b);
				
				//harusnya ada fungsi XOR, tapi baru asumsi, fungsi masih salah
				result += varXOR(temp,keyGen);
				
				a+=8;
				b++;
			}
			
			return result;
		}
		
		
		private String CBC(String key, String text){
		//mode enkripsi CBC
		//asumsi
		//1. panjang key = 8
		//2. panjang text merupakan kelipatan 8
		
			int a,b,c;
			int size;
			String temp = String.Empty;
			String keyGen = "00000000";
			String tempKey = String.Empty;
			String result = String.Empty;
			
			a=0;	//count jumlah char
			b=0;	//count jumlah penggunaan key
			while(a<text.Length){
				temp = text.substring(a,8);
				
				//melakukan XOR P dan C
				tempKey = varXOR(temp,keyGen);
				
				//harusnya ada fungsi XOR, tapi baru asumsi, fungsi masih salah
				result += varXOR(tempKey,keyGen);
				
				a+=8;
				b++;
			}
			
			return result;
		}

    }
}
