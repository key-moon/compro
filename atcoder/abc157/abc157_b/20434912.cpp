// detail: https://atcoder.jp/contests/abc157/submissions/20434912
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  vector<vector<int>> a(3, vector<int>(3));
  for (int i = 0; i < 3; i++) {
    for (int j = 0; j < 3; j++) {
      cin >> a[i][j];
    }
  }
  int n;
  cin >> n;
  for (int i = 0; i < n; i++) {
    int b;
    cin >> b;
    for (int i = 0; i < 3; i++) {
      for (int j = 0; j < 3; j++) {
        if (a[i][j] == b) a[i][j] = 0;
      }
    }
  }
  var res = false;
  res |= (!a[0][0] && !a[1][1] && !a[2][2]);
  res |= (!a[2][0] && !a[1][1] && !a[0][2]);
  for (int i = 0; i < 3; i++) {
    res |= (!a[i][0] && !a[i][1] && !a[i][2]);
    res |= (!a[0][i] && !a[1][i] && !a[2][i]);
  }
  cout << (res ? "Yes" : "No") << endl;
}
