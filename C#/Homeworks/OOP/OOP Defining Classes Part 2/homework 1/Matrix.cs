using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace homework_1
{
    //
    public class Matrix<T>
    {

        public T[,] elements;
        private int lenght { get; set; }
        public int rows { get; private set; }
        public int cols { get; private set; }
        public Matrix(int rows,int cols)
        {
            elements = new T[rows, cols];
            this.rows = rows;
            this.cols = cols;
        }
        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || col < 0 || row > elements.Length || col > elements.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.elements[row, col];
            }
            set
            {
                elements[row, col] = value;
            }
          
        }
        public static Matrix<double> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<double> newMatrix = new Matrix<double>(matrix1.rows,matrix1.cols);
            if (matrix1.lenght != matrix2.lenght)
	        {
	        	 throw new ArgumentException("Matricec lenght must be equal");
	        }
            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int g = 0; g < matrix1.cols; g++)
                {

                    newMatrix[i, g] = (double.Parse(matrix1[i, g].ToString()) + double.Parse(matrix2[i, g].ToString()));
                    
                }
            }
            return newMatrix;
        }
        public static Matrix<double> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<double> newMatrix = new Matrix<double>(matrix1.rows, matrix1.cols);
            if (matrix1.lenght != matrix2.lenght)
            {
                throw new ArgumentException("Matricec lenght must be equal");
            }
            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int g = 0; g < matrix1.cols; g++)
                {

                    newMatrix[i, g] = (double.Parse(matrix1[i, g].ToString()) - double.Parse(matrix2[i, g].ToString()));

                }
            }
            return newMatrix;
        }
        public static Matrix<double> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<double> newMatrix = new Matrix<double>(matrix1.rows, matrix1.cols);
            if (matrix1.lenght != matrix2.lenght)
            {
                throw new ArgumentException("Matricec lenght must be equal");
            }
            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int g = 0; g < matrix1.cols; g++)
                {

                    newMatrix[i, g] = (double.Parse(matrix1[i, g].ToString()) * double.Parse(matrix2[i, g].ToString()));

                }
            }
            return newMatrix;
        }
        public static bool operator true(Matrix<T> matrix1)
        {
            
            for (int cols = 0; cols < matrix1.cols ; cols++)
			{
                for (int rows = 0; rows < matrix1.rows; rows++)
                {
                    if (int.Parse(matrix1[rows,cols].ToString()) == 0)
                    {
                        return false;
                    }
                }
			}
            return true;
        }
        public static bool operator false(Matrix<T> matrix1)
        {
            for (int cols = 0; cols < matrix1.cols; cols++)
            {
                for (int rows = 0; rows < matrix1.rows; rows++)
                {
                    if (int.Parse(matrix1[rows, cols].ToString()) != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}