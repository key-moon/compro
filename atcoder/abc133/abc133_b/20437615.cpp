// detail: https://atcoder.jp/contests/abc133/submissions/20437615
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, d;
  cin >> n >> d;
  vector<vector<int>> dist(n, vector<int>(d));
  for (int i = 0; i < n; i++) {
    for (int j = 0; j < d; j++) cin >> dist[i][j];
  }
  int res = 0;
  for (int i = 0; i < n; i++) {
    for (int j = i + 1; j < n; j++) {
      ll sum = 0;
      for (int k = 0; k < d; k++) {
        var d = dist[i][k] - dist[j][k];
        sum += d * d;
      }
      var s = (int)round(sqrt(sum));
      if (s * s == sum) res++;
    }
  }
  cout << res << endl;
}
