#include <iostream>
using namespace std;

void printTriangle(int height, int length)
{
	int oddNum, numRows, restRows;

	for (int i = 0; i < (int)(length / 2); i++)//the space for the first row
		cout << " ";
	cout << "*\n";//print one star for the first row
	oddNum = (length - 1) / 2 - 1;//the number of the odd numbers between 1 to length
	numRows = (int)((height - 2) / oddNum);//the number of rows that each odd number has 
	restRows = (height - 2) % oddNum;//the rest of the rows to add for the number 3
	for (int i = 0; i < restRows + numRows; i++)//print 3 stars 
	{
		for (int j = 0; j < (int)(length / 2) - 1; j++)
			cout << " ";
		cout << "***\n";
	}
	for (int i = 5; i < oddNum * 2 + 3; i += 2)
	{
		for (int k = 0; k < numRows; k++)//the number of rows foe each odd number
		{
			for (int w = 0; w < (int)(length / 2) - (int)(i / 2); w++)//the space
				cout << " ";
			for (int j = 0; j < i; j++)//the stars
				cout << "*";
			cout << "\n";
		}
	}
	for (int i = 0; i < length; i++)//print stars for the last row
		cout << "*";
}

void checkHeight(int height)
{
	while (height < 2)
	{
		cout << "press a valid height that equals or bigger than 2: ";
		cin >> height;
	}
}
int main()
{
	int op;
	int triangleOp;
	int height, length;
	cout << "the option are:\n";
	cout << "Option 1: Rectangle\n";
	cout << "Option 2: Triangular\n";
	cout << "Option 3: Exit\n";
	cout << "press the number of the wanted option: ";
	cin >> op;

	while (op != 3)
	{
		switch (op)
		{
		case 1:
			cout << "\nenter height that equals or bigger than 2: ";
			cin >> height;
			//check height integrity
			checkHeight(height);
			cout << "enter length: ";
			cin >> length;
			//print the area or the perimeter depends on the inputs
			if (height == length || abs(height - length) > 5)
				cout << "\nArea of this Rectangle is: " << height * length << "\n";
			else
				cout << "\nPerimeter of this Rectangle is: " << 2 * height + 2 * length << "\n";
			break;
		case 2:
			cout << "\nenter height that equals or bigger than 2: ";
			cin >> height;
			//check height integrity
			checkHeight(height);
			cout << "enter length: ";
			cin >> length;
			//print the area or the triangle depends on the user request
			cout << "\nchoose an option:\n";
			cout << "option 1: Calculating the area of a triangle\n";
			cout << "option 2: printing the triangle\n";
			cin >> triangleOp;
			switch (triangleOp)
			{
			case 1:
				cout << "\nArea of this Triangle is: " << (height * length) / 2 << "\n";
				break;
			case 2:
				if (length % 2 == 0 || length > 2 * height)
					cout << "\nthere is not an option to print the triangle\n";
				else
					printTriangle(height, length);
				break;
			default:
				while (triangleOp != 2)
				{
					cout << "the number of the option is not correct, press again: ";
					cin >> triangleOp;
				}
			}

			break;
		default:
			cout << "the number of the option is not correct, press again\n";
		}
		cout << "\nthe option are:\n";
		cout << "Option 1: Rectangle\n";
		cout << "Option 2: Triangular\n";
		cout << "Option 3: Exit\n";
		cout << "press the number of the wanted option: ";
		cin >> op;
	}

	return 0;
}

/*the option are:
Option 1: Rectangle
Option 2: Triangular
Option 3: Exit
press the number of the wanted option: 2
enter height that equals or bigger than 2: 12
enter length: 9
choose an option:
option 1: Calculating the area of a triangle
option 2: printing the triangle
2
	*
   ***
   ***
   ***
   ***
  *****
  *****
  *****
 *******
 *******
 *******
*********
the option are:
Option 1: Rectangle
Option 2: Triangular
Option 3: Exit
press the number of the wanted option: 1
enter height that equals or bigger than 2: 4
enter length: 7
Perimeter of this Rectangle is: 22

the option are:
Option 1: Rectangle
Option 2: Triangular
Option 3: Exit
press the number of the wanted option: 1
enter height that equals or bigger than 2: 5
enter length: 5
Area of this Rectangle is: 25

the option are:
Option 1: Rectangle
Option 2: Triangular
Option 3: Exit
press the number of the wanted option: 1
enter height that equals or bigger than 2: 8
enter length: 2
Area of this Rectangle is: 16

the option are:
Option 1: Rectangle
Option 2: Triangular
Option 3: Exit
press the number of the wanted option: 2
enter height that equals or bigger than 2: 4
enter length: 3
choose an option:
option 1: Calculating the area of a triangle
option 2: printing the triangle
1
Area of this Triangle is: 6

the option are:
Option 1: Rectangle
Option 2: Triangular
Option 3: Exit
press the number of the wanted option: 2
enter height that equals or bigger than 2: 12
enter length: 11
choose an option:
option 1: Calculating the area of a triangle
option 2: printing the triangle
2
	 *
	***
	***
	***
	***
   *****
   *****
  *******
  *******
 *********
 *********
***********
the option are:
Option 1: Rectangle
Option 2: Triangular
Option 3: Exit
press the number of the wanted option: 3

C:\Users\shila\source\repos\HomeTask1\Debug\HomeTask1.exe (process 24652) exited with code 0.
Press any key to close this window . . .*/