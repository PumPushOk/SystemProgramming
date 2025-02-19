#include <iostream>
#include <Windows.h>  

using namespace std;

enum Color { white, black, red, blue, green, yellow, grey };

struct Point {
    float x, y;
    Color color;
};

const char* colorToString(Color color) {
    const char* colors[] = { "white", "black", "red", "blue", "green", "yellow", "grey" };
    return colors[color];
}

float calculateDistance(const Point& p1, const Point& p2) {
    return sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));
}

void findMaxDistance(Point points[], int size, Color color) {
    float maxDistance = 0;
    int maxP1 = -1, maxP2 = -1;

    for (int i = 0; i < size; i++) {
        for (int j = i + 1; j < size; j++) {
            if (points[i].color == color && points[j].color == color) {
                float distance = calculateDistance(points[i], points[j]);
                if (distance > maxDistance) {
                    maxDistance = distance;
                    maxP1 = i;
                    maxP2 = j;
                }
            }
        }
    }

    if (maxP1 != -1 && maxP2 != -1) {
        cout << "Колір: " << colorToString(color) << "\n";
        cout << "Макс. відстань: " << maxDistance << "\n";
        cout << "Точка 1: (" << points[maxP1].x << ", " << points[maxP1].y << ")\n";
        cout << "Точка 2: (" << points[maxP2].x << ", " << points[maxP2].y << ")\n\n";
    }
}


int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    const int size = 4;
    Point points[size];

    cout << "Введіть 20 точок у форматі: x y color (від 0 до 6):\n";
    for (int i = 0; i < size; i++) {
        int colorInput;
        cin >> points[i].x >> points[i].y >> colorInput;
        points[i].color = static_cast<Color>(colorInput);
    }

    cout << "\nВведені дані:\n";
    cout << "-----------------------------------------\n";
    cout << "|   X   |   Y   |        Color          |\n";
    cout << "-----------------------------------------\n";
    for (int i = 0; i < size; i++) {
        cout << "| " << points[i].x << " | " << points[i].y
            << " | " << colorToString(points[i].color) << " |\n";
    }
    cout << "-----------------------------------------\n\n";
    for (int color = white; color <= grey; color++) {
        findMaxDistance(points, size, static_cast<Color>(color));
    }

    return 0;
}