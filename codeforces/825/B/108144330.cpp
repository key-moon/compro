// detail: https://codeforces.com/contest/825/submission/108144330
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n = 10;
  vector<string> grid(n);
  for (int i = 0; i < n; i++) {
    cin >> grid[i];
  }
  for (int i = 0; i < n; i++) {
    for (int j = 0; j + 5 <= n; j++) {
      int xCnt = 0;
      for (int k = j; k < j + 5; k++) {
        if (grid[i][k] == 'O') goto invalid1;
        if (grid[i][k] == 'X') xCnt++;
      }
      if (xCnt < 4) goto invalid1;
      cout << "YES" << endl;
      return 0;
      invalid1:;
    }
  }

  for (int j = 0; j < n; j++) {
    for (int i = 0; i <= n - 5; i++) {
      int xCnt = 0;
      for (int k = i; k < i + 5; k++) {
        if (grid[k][j] == 'O') goto invalid2;
        if (grid[k][j] == 'X') xCnt++;
      }
      if (xCnt < 4) goto invalid2;
      cout << "YES" << endl;
      return 0;
    invalid2:;
    }
  }

  for (int ipj = 0; ipj <= 9 + 9; ipj++) {
    for (int i = 0; i <= n - 5; i++) {
      int xCnt = 0;
      for (int k = i; k < i + 5; k++) {
        int j = ipj - k;
        if (j < 0 || n <= j) goto invalid3;
        if (grid[k][j] == 'O') goto invalid3;
        if (grid[k][j] == 'X') xCnt++;
      }
      if (xCnt < 4) goto invalid3;
      cout << "YES" << endl;
      return 0;
    invalid3:;
    }
  }

  for (int imj = -(n - 1); imj <= n - 1; imj++) {
    for (int i = 0; i <= n - 5; i++) {
      int xCnt = 0;
      for (int k = i; k < i + 5; k++) {
        int j = imj + k;
        if (j < 0 || n <= j) goto invalid4;
        if (grid[k][j] == 'O') goto invalid4;
        if (grid[k][j] == 'X') xCnt++;
      }
      if (xCnt < 4) goto invalid4;
      cout << "YES" << endl;
      return 0;
    invalid4:;
    }
  }
  cout << "NO" << endl;
}
