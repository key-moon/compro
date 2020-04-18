// detail: https://atcoder.jp/contests/arc039/submissions/12045659
#include <bits/stdc++.h>

#define var auto
#define ll long long
//#define APPLY(a, f) f(a.begin(), a.end())
#define APPLY(a, f, ...) f(a.begin(), a.end(), __VA_ARGS__)
#define FUN1(x, f) [&](auto& x){return f;}
#define FUN2(x, y, f) [&](auto& x){return f;}

using namespace std;

int main() {
    int n;
    string s;
    cin >> n >> s;
    int curX = 0;
    int curY = 0;
    map<pair<int, int>, vector<pair<int, int>>> redirectedPoints{};
    redirectedPoints[make_pair(0, 0)] = vector<pair<int, int>>{make_pair(-1, 0), make_pair(0, -1), make_pair(1, 0), make_pair(0, 1)};
    for (auto&& c : s){
        int id;
        switch (c){
            case 'U':
                id = 0;
                break;
            case 'L':
                id = 1;
                break;
            case 'D':
                id = 2;
                break;
            case 'R':
                id = 3;
                break;
        }
        var curPoint = redirectedPoints[make_pair(curY, curX)];
        for (auto&& point : curPoint){
            if (!redirectedPoints.count(point))
                redirectedPoints[point] = vector<pair<int, int>>
                {
                    make_pair(point.first - 1, point.second),
                    make_pair(point.first, point.second - 1),
                    make_pair(point.first + 1, point.second),
                    make_pair(point.first, point.second + 1),
                };
        }
        for (int i = 0; i <= 1; ++i) {
            redirectedPoints[curPoint[i]][i + 2] = curPoint[i + 2];
            redirectedPoints[curPoint[i + 2]][i] = curPoint[i];
        }
        curX = curPoint[id].second;
        curY = curPoint[id].first;
    }
    cout << curX << " " << -curY << endl;
}
