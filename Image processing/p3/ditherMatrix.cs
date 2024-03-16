﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3
{
    internal class ditherMatrix
    {
        public int[,] D2 = { { 0, 2 },
                      { 3, 1 } };

        public int[,] D3 = { { 6, 8, 4 },
                      { 1, 0, 3 },
                      { 5, 2, 7 } };

        public int[,] D4 = { { 0, 8, 2, 10 },
                      { 12, 4, 14, 6 },
                      { 3, 11, 1, 9 },
                      { 15, 7, 13, 5 } };

        public int[,] D6 = {   { 24, 32, 16, 26, 34, 18 },
                        { 4, 0, 12, 6, 2, 14 },
                        { 20, 8, 28, 22, 10, 30 },
                        { 27, 35, 19, 25, 33, 17 },
                        { 7, 3, 15, 5, 1, 13 },
                        { 23, 11, 31, 21, 9, 29 } };

        public int[,] D8 = { { 0, 32, 8, 40, 2, 34, 10, 42 },
                      { 48, 16, 56, 24, 50, 18, 58, 26 },
                      { 12, 44, 4, 36, 14, 46, 6, 38 },
                      { 60, 28, 52, 20, 62, 30, 54, 22 },
                      { 3, 35, 11, 43, 1, 33, 9, 41 },
                      { 51, 19, 59, 27, 49, 17, 57, 25 },
                      { 15, 47, 7, 39, 13, 45, 5, 37 },
                      { 63, 31, 55, 23, 61, 29, 53, 21 } };

        public int[,] D12 = {  { 96, 128, 64, 104, 136, 72, 98, 130, 66, 106, 138, 74 },
                        { 16, 0, 48, 24, 8, 56, 18, 2, 50, 26, 10, 58 },
                        { 80, 32, 112, 88, 40, 120, 82, 34, 114, 90, 42, 122 },
                        { 108, 140, 76, 100, 132, 68, 110, 142, 78, 102, 134, 70 },
                        { 28, 12, 60, 20, 4, 52, 30, 14, 62, 22, 6, 54 },
                        { 92, 44, 124, 84, 36, 116, 94, 46, 126, 86, 38, 118 },
                        { 99, 131, 67, 107, 139, 75, 97, 129, 65, 105, 137, 73 },
                        { 19, 3, 51, 27, 11, 59, 17, 1, 49, 25, 9, 57 },
                        { 83, 35, 115, 91, 43, 123, 81, 33, 113, 89, 41, 121 },
                        { 111, 143, 79, 103, 135, 71, 109, 141, 77, 101, 133, 69 },
                        { 31, 15, 63, 23, 7, 55, 29, 13, 61, 21, 5, 53 },
                        { 95, 47, 127, 87, 39, 119, 93, 45, 125, 85, 37, 117 } };

        public int[,] D16 = {  {0, 128, 32, 160, 8, 136, 40, 168, 2, 130, 34, 162, 10, 138, 42, 170 },
                        {192, 64, 224, 96, 200, 72, 232, 104, 194, 66, 226, 98, 202, 74, 234, 106 },
                        {48, 176, 16, 144, 56, 184, 24, 152, 50, 178, 18, 146, 58, 186, 26, 154 },
                        {240, 112, 208, 80, 248, 120, 216, 88, 242, 114, 210, 82, 250, 122, 218, 90 },
                        {12, 140, 44, 172, 4, 132, 36, 164, 14, 142, 46, 174, 6, 134, 38, 166 },
                        {204, 76, 236, 108, 196, 68, 228, 100, 206, 78, 238, 110, 198, 70, 230, 102 },
                        {60, 188, 28, 156, 52, 180, 20, 148, 62, 190, 30, 158, 54, 182, 22, 150 },
                        {252, 124, 220, 92, 244, 116, 212, 84, 254, 126, 222, 94, 246, 118, 214, 86 },
                        {3, 131, 35, 163, 11, 139, 43, 171, 1, 129, 33, 161, 9, 137, 41, 169 },
                        {195, 67, 227, 99, 203, 75, 235, 107, 193, 65, 225, 97, 201, 73, 233, 105 },
                        {51, 179, 19, 147, 59, 187, 27, 155, 49, 177, 17, 145, 57, 185, 25, 153 },
                        {243, 115, 211, 83, 251, 123, 219, 91, 241, 113, 209, 81, 249, 121, 217, 89 },
                        {15, 143, 47, 175, 7, 135, 39, 167, 13, 141, 45, 173, 5, 133, 37, 165 },
                        {207, 79, 239, 111, 199, 71, 231, 103, 205, 77, 237, 109, 197, 69, 229, 101 },
                        {63, 191, 31, 159, 55, 183, 23, 151, 61, 189, 29, 157, 53, 181, 21, 149 },
                        {255, 127, 223, 95, 247, 119, 215, 87, 253, 125, 221, 93, 245, 117, 213, 85 }  };

    }
}