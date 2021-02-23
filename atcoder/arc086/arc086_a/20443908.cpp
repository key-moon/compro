// detail: https://atcoder.jp/contests/arc086/submissions/20443908
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int k, n;
  cin >> n >> k;
  vector<int> cnts(n + 1);
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    cnts[a]++;
  }
  sort(cnts.begin(), cnts.end(), greater<int>());
  int cnt = 0;
  int res = 0;
  for (var&& i : cnts) {
    if (i == 0) continue;
    if (k <= cnt) {
      res += i;
    }
    cnt++;
  }
  cout << res << endl;
}
