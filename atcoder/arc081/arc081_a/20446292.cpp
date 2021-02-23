// detail: https://atcoder.jp/contests/arc081/submissions/20446292
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
  map<int, int> cnt{};
  vector<ll> usable{};
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    cnt[a]++;
    if (cnt[a] % 2 == 0) usable.emplace_back(a);
  }
  sort(usable.begin(), usable.end(), greater<int>());
  if (usable.size() < 2) {
    cout << 0 << endl;
    return 0;
  }
  cout << usable[0] * usable[1] << endl;
}
