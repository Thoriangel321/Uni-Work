using System;
using System.Collections;
using System.Net.NetworkInformation;
using System.Numerics;
using Lab3._2;

VectorCL v1 = new VectorCL("Red", 10.0, 5.0);
VectorCL v2 = new VectorCL("Yellow", -3.0, 4.0);
VectorCL v3 = new VectorCL("Blue", 1.0, 8.0);
VectorCL v4 = new VectorCL("Dark Green", -9.0, 0.5);
VectorCL v5 = new VectorCL("Black", 3.0, 1.5);


System.Console.WriteLine("--Array--");
//Arrays have fixed size. cannot dynamically Add something or Remove, there are ways but nah |>.<|
VectorCL[] vectorsArray = new VectorCL[5];  //Array

//aading values to array
vectorsArray[0] = v1;
vectorsArray[1] = v2;
vectorsArray[2] = v3;
vectorsArray[3] = v4;
vectorsArray[4] = v5;

//update
vectorsArray[2].color = "Dark Blue";

//search
VectorCL foundInArray = Array.Find(vectorsArray, v => v.color == "Black");
System.Console.WriteLine($"found in array: {foundInArray?.color}");

//iterate
for(int i = 0; i < 5; i++)
{
    System.Console.WriteLine($"Array: {vectorsArray[i].color} at ({vectorsArray[i].x}, {vectorsArray[i].y})");

}

System.Console.WriteLine("--generic collection aka list--");
//strongly typed, dynamically sized..
List<VectorCL> listedVectors = new List<VectorCL>();    //List

listedVectors.Add(v1);
listedVectors.Add(v2);
listedVectors.Add(v3);
listedVectors.Add(v4);
listedVectors.Add(v5);

//update
listedVectors[2].x = 0.5f;

//search
VectorCL foundInList = listedVectors.Find(v => v.color == "Dark Green");
System.Console.WriteLine($"found in list: {foundInList?.color}");

//remove
listedVectors.Remove(v5); // or RemoveAt(4);

//iterate
foreach(VectorCL vec in listedVectors)
{
    System.Console.WriteLine($"List Element: {vec.color} at ({vec.x}, {vec.y})");
}

System.Console.WriteLine("-- non-generic collection aka arraylist--");
// ArrayList is weakly-typed so it stores everything as object and thus requires casting...

ArrayList arrayListVectors = new ArrayList();   //ArrayList;

arrayListVectors.Add(v1);
arrayListVectors.Add(v2);
arrayListVectors.Add(v3);
arrayListVectors.Add(v4);
arrayListVectors.Add(v5);

//update | it requires a cast (VectorCL) because it returns as 'object'
((VectorCL)arrayListVectors[2])?.y = 14.5f;

//search | it has no built-in search so must iterate 

VectorCL foundInArraylist = null;
foreach(object obj in arrayListVectors)
{
    VectorCL temp = (VectorCL)obj;
    if(temp.color == "Yellow")
    {
        foundInArraylist = temp;
        System.Console.WriteLine($"found in ArrayList: {foundInArraylist.color}");
        break;
    }
}

//remove 
arrayListVectors.RemoveAt(3);   

//iterate 
foreach(object obj in arrayListVectors)
{
    VectorCL vec = (VectorCL)obj;
    System.Console.WriteLine($"ArrayList Vector: {vec.color} at ({vec.x}, {vec.y})");
}

Console.WriteLine("-- Binary Tree --");

BinaryTree<VectorCL> vectorTree = new BinaryTree<VectorCL>();

vectorTree.Insert(v1);
vectorTree.Insert(v2);
vectorTree.Insert(v3);
vectorTree.Insert(v4);
vectorTree.Insert(v5);

foreach (VectorCL vec in vectorTree) 
{
    Console.WriteLine(vec.ToString());
}