// detail: https://atcoder.jp/contests/abc088/submissions/20443459
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  vector<vector<int>> mat(3, vector<int>(3));
  for (int i = 0; i < 3; i++) {
    for (int j = 0; j < 3; j++) {
      cin >> mat[i][j];
    }
  }
  vector<int> a = mat[0];
  vector<int> b(3);
  for (int i = 0; i < 3; i++) {
    b[i] = mat[i][0] - a[0];
  }
  for (int i = 0; i < 3; i++) {
    for (int j = 0; j < 3; j++) {
      if (a[j] + b[i] != mat[i][j]) {
        cout << "No" << endl;
        return 0;
      }
    }
  }
  cout << "Yes" << endl;
  return 0;
}
