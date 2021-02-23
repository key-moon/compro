// detail: https://atcoder.jp/contests/code-festival-2016-quala/submissions/20441095
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MOD = (int)1e9 + 7;

int main() {
  int n;
  cin >> n;
  vector<int> a(n);
  for (int i = 0; i < n; i++) {
    cin >> a[i];
    a[i]--;
  }
  int res = 0;
  for (int i = 0; i < n; i++) {
    if (i == a[a[i]]) res++;
  }
  cout << res / 2 << endl;
}
