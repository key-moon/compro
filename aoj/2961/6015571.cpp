// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2961/judge/6015571/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  vector<int> accum(1e5 + 1);
  for (ll i = 2; i < accum.size(); i++) {
    accum[i] = accum[i - 1];
    ll prod = 1;
    for (int j = 1; j * j <= i; j++) {
      if (i * i * 2 <= prod) continue;
      if (i % j != 0) continue;

      prod *= j;
      var k = i / j;
      if (j < k) prod *= k;

    }
    prod /= i;
    if (i * 2 <= prod) accum[i]++;
  }
  int q;
  cin >> q;
  for (int i = 0; i < q; i++) {
    int n;
    cin >> n;
    cout << accum[n] << endl;
  }
}


