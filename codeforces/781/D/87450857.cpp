// detail: https://codeforces.com/contest/781/submission/87450857
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;

bool possibleWithP[62][500][500];
bool possibleWithR[62][500][500];

int main() {
	int n, m;
	cin >> n >> m;
    for (int i = 0; i < m; i++)
    {
        int s, t, k;
        cin >> s >> t >> k;
        s--; t--;
        (k == 0 ? possibleWithP : possibleWithR)[0][s][t] = true;
    }
    for (int i = 1; i < 62; i++)
    {
        vector<bitset<500>> pf(500, bitset<500>());
        vector<bitset<500>> ps(500, bitset<500>());
        vector<bitset<500>> rf(500, bitset<500>());
        vector<bitset<500>> rs(500, bitset<500>());
        for (size_t j = 0; j < n; j++)
        {
            for (size_t k = 0; k < n; k++)
            {
                if (possibleWithP[i - 1][j][k])
                {
                    pf[j].set(k);
                    ps[k].set(j);
                }
                if (possibleWithR[i - 1][j][k])
                {
                    rf[j].set(k);
                    rs[k].set(j);
                }
            }
        }
        
        for (int start = 0; start < n; start++)
        {
            for (int end = 0; end < n; end++)
            {
                var s = pf[start];
                s &= rs[end];
                possibleWithP[i][start][end] = s.any();
            }
        }

        for (int start = 0; start < n; start++)
        {
            for (int end = 0; end < n; end++)
            {
                var s = rf[start];
                s &= ps[end];
                possibleWithR[i][start][end] = s.any();
            }
        }

        for (int start = 0; start < n; start++)
            for (int end = 0; end < n; end++)
                if (possibleWithP[i][start][end] || possibleWithR[i][start][end])
                    goto valid;
        break;
    valid:;
    }
    ll res = 0;
    int next = 0;
    vector<int> candStarts{ 0 };
    for (int i = 62 - 1; i >= 0; i--)
    {
        vector<int> newStarts{};
        var possible = (next == 0 ? possibleWithP : possibleWithR)[i];
        for (size_t i = 0; i < n; i++)
        {
            for (var&& cand : candStarts) {
                if (possible[cand][i]) {
                    newStarts.push_back(i);
                    break;
                }
            }
        }
        if (newStarts.empty()) {
            continue;
        }
        res |= 1LL << i;
        next ^= 1;
        candStarts = move(newStarts);
    }
    if (1000000000000000000 <= res) res = -1;
    cout << res << endl;
}
