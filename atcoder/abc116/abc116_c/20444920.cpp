// detail: https://atcoder.jp/contests/abc116/submissions/20444920
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  vector<int> h(n);
  for (int i = 0; i < n; i++) cin >> h[i];
  int res = 0;
  for (int i = 0; i < n; i++) {
    while (h[i] != 0) {
      for (int j = i; j < n; j++) {
        if (h[j] == 0) break;
        h[j]--;
      }
      res++;
    }
  }
  cout << res << endl;
}
