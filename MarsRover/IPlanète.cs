﻿namespace MarsRover;

public interface IPlanète
{
    (int X, int Y, bool Libre) Normaliser(int x, int y);
}