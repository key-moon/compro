// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2000/judge/4362717/C++14
#include <bits/stdc++.h>

#define var auto
#define long long long
using namespace std;

int main() {
    while(true){
        int n;
        cin >> n;
        if (n == 0) break;
        vector<vector<bool>> exists(21, vector<bool>(21, false));
        for (int i = 0; i < n; ++i) {
            int x, y;
            cin >> x >> y;
            exists[x][y] = true;
        }
        int m;
        cin >> m;
        int curX = 10, curY = 10;
        exists[curX][curY] = false;
        for (int i = 0; i < m; ++i) {
            char dir; int dist;
            cin >> dir >> dist;
            int* axis = dir == 'E' || dir == 'W' ? &curX : &curY;
            int moveDir = dir == 'N' || dir == 'E' ? 1 : -1;
            for (int j = 0; j < dist; ++j) {
                *axis += moveDir;
                exists[curX][curY] = false;
            }
        }
        auto verdict = all_of(exists.begin(), exists.end(), [](auto x){ return all_of(x.begin(), x.end(), [](auto y){return !y;}); });
        cout << (verdict ? "Yes" : "No") << endl;
    }
}

